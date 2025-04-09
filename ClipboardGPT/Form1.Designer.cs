using System.Windows.Forms;

namespace ClipboardGPT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Define menu items
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem sendToChatGptItem;
        private ToolStripMenuItem improveTextItem;
        private ToolStripMenuItem makeItFunnyItem;
        private ToolStripMenuItem summarizeTextItem;
        private ToolStripMenuItem translateTextItem;
        private ToolStripMenuItem formalizeToneItem;
        private ToolStripMenuItem casualizeToneItem;

        // Dispose method to clean up components
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Initialize UI components
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToChatGptItem = new System.Windows.Forms.ToolStripMenuItem();
            this.improveTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeItFunnyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summarizeTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateTextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formalizeToneItem = new System.Windows.Forms.ToolStripMenuItem();
            this.casualizeToneItem = new System.Windows.Forms.ToolStripMenuItem();

            // Add items to context menu
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.sendToChatGptItem,
                this.improveTextItem,
                this.makeItFunnyItem,
                this.summarizeTextItem,
                this.translateTextItem,
                this.formalizeToneItem,
                this.casualizeToneItem
            });

            // Set text for the menu items
            this.sendToChatGptItem.Text = "Send to ChatGPT";
            this.sendToChatGptItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);

            // Optionally add more functionality to other items
            this.improveTextItem.Text = "Improve Text";
            this.makeItFunnyItem.Text = "Make it Funny";
            this.summarizeTextItem.Text = "Summarize Text";
            this.translateTextItem.Text = "Translate Text";
            this.formalizeToneItem.Text = "Formalize the Tone";
            this.casualizeToneItem.Text = "Casualize the Tone";
            // Inside InitializeComponent()
            this.sendToChatGptItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.improveTextItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.makeItFunnyItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.summarizeTextItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.translateTextItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.formalizeToneItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);
            this.casualizeToneItem.Click += new System.EventHandler(this.SendToChatGptToolStripMenuItem_Click);


            // Assign the context menu to the form
            this.ContextMenuStrip = this.contextMenu;

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Clipboard GPT";
        }
    }
}
