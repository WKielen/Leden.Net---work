using System.Windows.Forms;

namespace Leden.Net
{
    public partial class frmHelp : frmBasis
    {
        public frmHelp(Form frm)
        {
            InitializeComponent();

            if (frm.GetType() == typeof(frmLeden))
            {
                rtbHelp.Text =
                "ctrl-A          Notes           " + "\n" +
                "ctrl-F          Search          " + "\n" +
                "ctrl-L          Explorer Logfiles" + "\n" +

                "ctrl-B          Bondsnummer     " + "\n" +
                "ctrl-T          Telefoon" + "\n" +
                "ctrl-M          Mobiel" + "\n" +
                "ctrl-E          Email" + "\n" +

                "ctrl-shift-T    Telefoon Ouders" + "\n" +
                "ctrl-shift-M    Mobiel Ouders" + "\n" +
                "ctrl-shift-E    Email Ouders";

            }


        }
    }
}
