using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessageFlowPanel
{
    [ProvideToolboxControl("MessageFlowPanel", false)]
    public partial class MessageFlowPanel : UserControl
    {
        public MessageFlowPanel()
        {
            InitializeComponent();
            mainFlowPanel.AutoScroll = false;
            mainFlowPanel.HorizontalScroll.Enabled = false;
            mainFlowPanel.HorizontalScroll.Visible = false;
            mainFlowPanel.AutoScroll = true;
        }

        /// <summary>
        /// Its add message balloon to left side of message panel.
        /// </summary>
        /// <param name="message">Message string</param>
        /// <param name="sender">Sender name</param>
        /// <param name="time">Message time</param>
        /// <param name="senderColor">For changing sender's name font color</param>
        /// <param name="fontName">For changing message font family</param>
        public void addMessageBalloonToLeft(string message, string sender, Color? senderColor = null, string fontName = null, DateTime? time = null)
        {
            ChatBubble cb = new ChatBubble(mainFlowPanel);
            cb.CreateChatBubble(ChatBubble.Location.Left, message, sender, Color.White, senderColor, fontName, time);
        }

        /// <summary>
        /// Its add message balloon to right side of message panel.
        /// </summary>
        /// <param name="message">Message string</param>
        /// <param name="sender">Sender name</param>
        /// <param name="time">Message time</param>
        /// <param name="senderColor">For changing sender's name font color</param>
        /// <param name="fontName">For changing message font family</param>
        public void addMessageBalloonToRight(string message, string sender, Color? senderColor = null, string fontName = null, DateTime? time = null)
        {
            ChatBubble cb = new ChatBubble(mainFlowPanel);
            cb.CreateChatBubble(ChatBubble.Location.Right, message, sender, Color.GreenYellow, senderColor, fontName, time);
        }

        private void mainFlowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            FlowLayoutPanel mfp = sender as FlowLayoutPanel;
            mfp.ScrollControlIntoView(e.Control);
        }

    }
}
