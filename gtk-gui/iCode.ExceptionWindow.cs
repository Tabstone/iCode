
// This file has been generated by the GUI designer. Do not modify.
namespace iCode
{
	public partial class ExceptionWindow
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Label ExceptionType;

		private global::Gtk.Label ExceptionTitle;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.Label ExceptionStacktrace;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget iCode.ExceptionWindow
			this.Name = "iCode.ExceptionWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("ExceptionWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child iCode.ExceptionWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(9));
			// Container child vbox1.Gtk.Box+BoxChild
			this.ExceptionType = new global::Gtk.Label();
			this.ExceptionType.Name = "ExceptionType";
			this.ExceptionType.Xalign = 0F;
			this.ExceptionType.LabelProp = global::Mono.Unix.Catalog.GetString("Exception");
			this.ExceptionType.UseMarkup = true;
			this.vbox1.Add(this.ExceptionType);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.ExceptionType]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.ExceptionTitle = new global::Gtk.Label();
			this.ExceptionTitle.Name = "ExceptionTitle";
			this.ExceptionTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Object is set");
			this.ExceptionTitle.UseMarkup = true;
			this.vbox1.Add(this.ExceptionTitle);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.ExceptionTitle]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox1.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hseparator1]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.ExceptionStacktrace = new global::Gtk.Label();
			this.ExceptionStacktrace.Name = "ExceptionStacktrace";
			this.ExceptionStacktrace.LabelProp = global::Mono.Unix.Catalog.GetString("label3");
			this.ExceptionStacktrace.UseMarkup = true;
			this.vbox1.Add(this.ExceptionStacktrace);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.ExceptionStacktrace]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 378;
			this.DefaultHeight = 273;
			this.Show();
		}
	}
}
