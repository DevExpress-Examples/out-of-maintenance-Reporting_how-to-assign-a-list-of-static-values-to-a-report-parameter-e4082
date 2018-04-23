#region #Reference
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
// ...
#endregion #Reference

namespace StaticParameterValues {
#region #Code
public partial class XtraReport1 : XtraReport {
    public XtraReport1() {
        InitializeComponent();

        // Create a parameter and define its main properties.
        Parameter parameter1 = new Parameter();
        parameter1.Type = typeof(System.Int32);
        parameter1.Name = "parameterProduct";
        parameter1.Visible = true;
        parameter1.Description = "Product Name: ";

        // Adjust the look-up settings to obtain 
        // the parameter values from the report's data source.
        parameter1.LookUpSettings = new StaticListLookUpSettings();
        ((StaticListLookUpSettings)parameter1.LookUpSettings).LookUpValues.AddRange(new LookUpValue[] {
            new LookUpValue("1", "Chai"), 
            new LookUpValue("2", "Chang"), 
            new LookUpValue("3", "Aniseed Syrup")
            });

        // Add the parameter to the report's collection,
        // and filter the report based on the parameter's value.
        this.Parameters.Add(parameter1);
        this.FilterString = "[ProductID] = ?parameterProduct";

        // Display the current parameter value in the report.
        XRLabel label = new XRLabel();
        this.Detail.Controls.Add(label);
        label.DataBindings.Add(new XRBinding(parameter1, "Text", ""));
        label.LocationFloat = new DevExpress.Utils.PointFloat(377.0833F, 10.00001F);

        // Pass a value to the parameter and publish the report.
        parameter1.Value = 1;
        this.RequestParameters = false;
    }
}
#endregion #Code
}
