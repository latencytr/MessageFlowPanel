using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageFlowPanel
{
    internal class ChatBubble
    {
        public enum Location
        {
            Left = 0,
            Right = 1
        }

        private string message = "";

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string sender = "";

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        private Color senderColor = Color.HotPink;

        public Color SenderColor
        {
            get { return senderColor; }
            set { senderColor = value; }
        }

        private DateTime time = DateTime.Now;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private string fontName = "TR Eagles";

        public string FontName
        {
            get { return fontName; }
            set { fontName = value; }
        }

        private Location location = Location.Left;

        private int width = 150;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private Color bubbleColor = Color.White;

        public Color BubbleColor
        {
            get { return bubbleColor; }
            set { bubbleColor = value; }
        }

        private FlowLayoutPanel mainFlowPanel;
        private Panel balloon;


        public ChatBubble(FlowLayoutPanel mainFlowPanel)
        {
            this.mainFlowPanel = mainFlowPanel;
        }

        public void CreateChatBubble(Location location, string message, string sender, Color? bubbleColor = null, Color? senderColor = null, string fontName = null, DateTime? time = null)
        {
            this.location = location;
            this.bubbleColor = bubbleColor ?? this.bubbleColor;
            mainFlowPanel.Resize += mainFlowPanel_Resize;
            Panel lineOfMessage = new Panel();
            lineOfMessage.AutoSize = true;
            lineOfMessage.Size = new Size(mainFlowPanel.Width, 32);
            lineOfMessage.MinimumSize = new Size(mainFlowPanel.Width, 32);
            lineOfMessage.MaximumSize = new Size(mainFlowPanel.Width, 0);
            lineOfMessage.Paint += lineOfMessage_Paint;
            Panel balloon = new Panel();
            balloon.BackColor = bubbleColor ?? this.bubbleColor;
            balloon.AutoSize = true;
            balloon.MinimumSize = new Size(width, 32);
            balloon.MaximumSize = new Size(width, 0);
            this.balloon = balloon;
            mainFlowPanel_Resize(balloon, new EventArgs());
            Panel senderAndTime = new Panel();
            senderAndTime.BackColor = bubbleColor ?? this.bubbleColor;
            senderAndTime.AutoSize = true;
            senderAndTime.MinimumSize = new Size(width, 13);
            senderAndTime.MaximumSize = new Size(width, 0);
            senderAndTime.Dock = DockStyle.Top;
            Label lblSender = new Label();
            lblSender.Text = sender;
            lblSender.ForeColor = senderColor ?? this.senderColor;
            lblSender.Font = new Font(fontName ?? this.fontName, 8, FontStyle.Bold);
            lblSender.TextAlign = ContentAlignment.MiddleLeft;
            lblSender.AutoSize = true;
            lblSender.MinimumSize = new Size(width - 35, 13);
            lblSender.MaximumSize = new Size(width - 35, 13);
            Label lblTime = new Label();
            lblTime.Size = new Size(35, 13);
            lblTime.Location = new Point(senderAndTime.Width - lblTime.Width - 1, senderAndTime.Height - lblTime.Height);
            lblTime.Text = (time ?? this.time).ToShortTimeString();
            lblTime.ForeColor = Color.Black;
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            lblTime.Font = new Font(fontName ?? this.fontName, 6, FontStyle.Regular);
            Label lblMessage = new Label();
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Font = new Font(fontName ?? this.fontName, 8, FontStyle.Bold);
            lblMessage.Location = new Point(3, 3);
            lblMessage.Text = message;
            lblMessage.ForeColor = Color.Black;
            lblMessage.AutoSize = true;
            lblMessage.MaximumSize = new Size(width, 0);
            lblMessage.TextAlign = ContentAlignment.TopLeft;
            senderAndTime.Controls.Add(lblSender);
            senderAndTime.Controls.Add(lblTime);
            balloon.Controls.Add(senderAndTime);
            balloon.Controls.Add(lblMessage);
            lineOfMessage.Controls.Add(balloon);
            mainFlowPanel.Controls.Add(lineOfMessage);
            mainFlowPanel.ScrollControlIntoView(lineOfMessage);
        }

        void lineOfMessage_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = panel.CreateGraphics();
            Pen p = new Pen(bubbleColor);
            SolidBrush sb = new SolidBrush(bubbleColor);
            Point[] triangle;
            if (location == Location.Right)
            {
                triangle = new Point[] { new Point(balloon.Right, balloon.Bottom), new Point(balloon.Right + 6, balloon.Bottom), new Point(balloon.Right, balloon.Bottom - 6) };
            }
            else
            {
                triangle = new Point[] { new Point(balloon.Left, balloon.Bottom), new Point(balloon.Left - 6, balloon.Bottom), new Point(balloon.Left, balloon.Bottom - 6) };
            }
            g.DrawPolygon(p, triangle);
            g.FillPolygon(sb, triangle);
        }

        void mainFlowPanel_Resize(object sender, EventArgs e)
        {
            if (location == Location.Left)
            {
                balloon.Left = 9;
            }
            else
            {
                int left = mainFlowPanel.Width - width - 38;
                if (mainFlowPanel.Width < 38)
                {
                    balloon.Left = 38;
                }
                else
                {
                    balloon.Left = left;
                }
            }
        }

        void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

    }
}
