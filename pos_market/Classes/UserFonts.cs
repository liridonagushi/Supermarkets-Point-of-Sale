using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;

namespace Supermarkets.Classes
{
    class UserFonts
    {
        public static iTextSharp.text.Font GetBoldFont()
        {
            var fontName = "FontBold";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\theboldfont.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }

        public static iTextSharp.text.Font TimeLine12()
        {
            var fontName = "Timeline Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Timeline.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 12);
        }
        

        public static iTextSharp.text.Font TimeLine14()
        {
            var fontName = "Timeline Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Timeline.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 14);
        }

        public static iTextSharp.text.Font TimeLine20()
        {
            var fontName = "Timeline Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Timeline.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 20);
        }

        public static iTextSharp.text.Font Swiss721_12()
        {
            var fontName = "Swis721 Lt BT Light";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/tt0001m.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 12);
        }

        public static iTextSharp.text.Font Swiss721_14()
        {
            var fontName = "Swis721 Lt BT Light";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/tt0001m.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 14);
        }

        public static iTextSharp.text.Font Swiss721_20()
        {
            var fontName = "Swis721 Lt BT Light";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/tt0001m.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 20);
        }

        public static iTextSharp.text.Font FontBold12()
        {
            var fontName = "Oswaldesque Bold";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Oswaldesque Bold.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 12);
        }

        public static iTextSharp.text.Font FontBold14()
        {
            var fontName = "Oswaldesque Bold";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Oswaldesque Bold.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 14);
        }

        public static iTextSharp.text.Font FontBold16()
        {
            var fontName = "Oswaldesque Bold";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Oswaldesque Bold.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 16);
        }

        public static iTextSharp.text.Font FontBold20()
        {
            var fontName = "Oswaldesque Bold";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/Oswaldesque Bold.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 20);
        }

        public static iTextSharp.text.Font fontNeue12()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 12);
        }

        public static iTextSharp.text.Font fontNeue14()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 14);
        }

        public static iTextSharp.text.Font fontNeue16()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 16);
        }

        public static iTextSharp.text.Font fontNeue18()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 18);
        }

        public static iTextSharp.text.Font fontNeue20()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 20);
        }

        public static iTextSharp.text.Font fontNeue25()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 25);
        }

        public static iTextSharp.text.Font fontNeue30()
        {
            var fontName = "Front Page Neue Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/FrontPageNeue.otf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 30);
        }

        public static iTextSharp.text.Font BPtypewriteStrike14()
        {
            var fontName = "BPtypewriteStrikethrough Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/BPtypewriteStrikethrough.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 14);
        }

        public static iTextSharp.text.Font BPtypewriteStrike16()
        {
            var fontName = "BPtypewriteStrikethrough Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/BPtypewriteStrikethrough.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 16);
        }

        public static iTextSharp.text.Font BPtypewriteStrike18()
        {
            var fontName = "BPtypewriteStrikethrough Regular";
            if (!FontFactory.IsRegistered(fontName))
            {
                //fontnamesize = "Front Page Neue, 14";

                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "/fonts/BPtypewriteStrikethrough.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, 18);
        }
    }
}
