using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Util.Forms
{
	public interface IMruUser
	{
		void ItemSelected(object obj);
	}

	public class MosaicMru
	{
		int maxItemsSave = 30;
		int maxItemsShow = 10;
		IMruUser parent;
		bool itemIsFile = true;
		bool _ignoreCase = true;

		string identifier;
		ArrayList mruList = new ArrayList();
		static readonly string IsolatedStoragePath;
		readonly string IsolatedStorageFile;
		static MosaicMru()
		{
			IsolatedStoragePath = System.Reflection.Assembly.GetEntryAssembly().GetName(false).Name + @"\";
		}
		private MosaicMru(){}
		public MosaicMru(IMruUser parent, string identifier)
		{
			this.parent = parent;
			this.identifier = identifier;
			// Load from local storage
			IsolatedStorageFile = identifier + ".mru";
			LoadList();
		}
		private static string DefaultKeyGenerator(object obj)
		{
			return obj.ToString();
		}
		#region Properties
		public int ItemsShowLimit
		{
			get { return maxItemsShow; }
			set
			{ 
				if (value < 1) throw new ArgumentOutOfRangeException("ItemsShowLimit", value, "value must be larger than 0");
				maxItemsShow = value;
			}
		}
		public int ItemsSaveLimit
		{
			get { return maxItemsSave; }
			set
			{ 
				if (value < 1) throw new ArgumentOutOfRangeException("ItemsSaveLimit", value, "value must be larger than 0");
				maxItemsSave = value;
			}
		}
		public bool ItemsAreFiles
		{
			get { return itemIsFile; }
			set { itemIsFile = value; }
		}
		public bool IgnoreCase
		{
			get { return _ignoreCase; }
			set
			{
				if (_ignoreCase == value)	return;
				_ignoreCase = value;
				LoadList();
			}
		}
		#endregion
		private void LoadList()
		{
			mruList.Clear();
			string fileList = PersistControlValue.ReadLocalAppSetting(IsolatedStoragePath, IsolatedStorageFile);
			if (fileList == null || fileList.Length == 0)
				return;
			string[] files = fileList.Split(Environment.NewLine.ToCharArray());
			foreach(string file in files)
				if (file != null && file.Length > 0 && !Contains(file))
					Add(file);
		}
		public void SaveList()
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < ItemsSaveLimit && i < mruList.Count; i++)
			{
				string name = mruList[i] as string;
				if (name != null && name.Length > 0)
				{
					sb.Append(name);
					sb.Append(Environment.NewLine);
				}
			}
			PersistControlValue.SaveLocalAppSetting(IsolatedStoragePath, IsolatedStorageFile, sb.ToString());
		}
		public void Add(string obj)
		{
			if (Contains(obj))
				MoveToTop(obj);
			else
				mruList.Add(obj);
		}
		public void Remove(string obj)
		{
			InternalRemove(obj);
		}
		public void MoveToTop(string obj)
		{
			int idx = IndexOf(obj);
			if (idx <= 0)	return;
			mruList.RemoveAt(idx);
			mruList.Insert(0, obj);
		}
		public void MoveToBottom(string obj)
		{
			int idx = IndexOf(obj);
			if (idx < 0)	return;	// not found
			if (idx == mruList.Count - 1)	return; // already at bottom
			mruList.RemoveAt(idx);
			mruList.Add(obj);
		}
		public void BuildMenu(MenuItem parent)
		{
			parent.MenuItems.Clear();
			for(int i = 0; i < ItemsShowLimit && i < mruList.Count; i++)
			{
				string name = mruList[i] as string;
				if (name != null && name.Length > 0)
					parent.MenuItems.Add(name, new EventHandler(this.mnuMRUItemClick));
			}
		}

        public void Clear()
        {
            mruList.Clear();
        }

		private void InternalRemove(string obj)
		{
			int idx = IndexOf(obj);
			if (idx < 0)	return;
			mruList.RemoveAt(idx);
		}
		public bool Contains(string obj)
		{
			return IndexOf(obj) >= 0;
		}
		private int IndexOf(string obj)
		{
			bool ignoreCase = IgnoreCase;
			for(int i = 0; i < mruList.Count; i++)
				if (string.Compare((string) mruList[i], obj, ignoreCase, System.Globalization.CultureInfo.InvariantCulture) == 0)
					return i;
			return -1;
		}
        private string FindItem(ToolStripDropDownItem mi)
		{
			int idx = IndexOf(mi.Text);
			if (idx < 0)	return string.Empty;
			return (string) mruList[idx];
		}
		private void mnuMRUItemClick(object sender, EventArgs args)
		{
            ToolStripDropDownItem di = sender as ToolStripDropDownItem;
            if (di == null) return;
            string obj = FindItem(di);
			if (ItemsAreFiles && !File.Exists(obj))
			{
				InternalRemove(obj);
				return;
			}

			MoveToTop(obj);
			parent.ItemSelected(obj);
		}
		public string[] ToArray()
		{
			return (string[]) mruList.ToArray(typeof(string));
		}

        public void BuildMenu(ToolStripMenuItem parent)
        {
            parent.DropDownItems.Clear();
            for (int i = 0; i < ItemsShowLimit && i < mruList.Count; i++)
            {
                string name = mruList[i] as string;
                if (name != null && name.Length > 0)
                    parent.DropDownItems.Add(name,null , new EventHandler(this.mnuMRUItemClick));
            }
        }

        public void BuildMenu(CheckedListBox parent)
        {
            parent.Items.Clear();
            for (int i = 0; i < ItemsShowLimit && i < mruList.Count; i++)
            {
                string name = mruList[i] as string;
                if (name != null && name.Length > 0)
                    parent.Items.Add(name);
            }
        }

    }
}