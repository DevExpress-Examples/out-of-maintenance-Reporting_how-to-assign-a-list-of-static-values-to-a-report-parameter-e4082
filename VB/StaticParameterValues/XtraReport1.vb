Imports Microsoft.VisualBasic
#Region "#Reference"
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
' ...
#End Region ' #Reference

Namespace StaticParameterValues
#Region "#Code"
Partial Public Class XtraReport1
	Inherits XtraReport
	Public Sub New()
		InitializeComponent()

		' Create a parameter and define its main properties.
		Dim parameter1 As New Parameter()
		parameter1.Type = GetType(System.Int32)
		parameter1.Name = "parameterProduct"
		parameter1.Visible = True
		parameter1.Description = "Product Name: "

		' Adjust the look-up settings to obtain 
		' the parameter values from the report's data source.
		parameter1.LookUpSettings = New StaticListLookUpSettings()
		CType(parameter1.LookUpSettings, _ 
		StaticListLookUpSettings).LookUpValues.AddRange(New LookUpValue() { _ 
				New LookUpValue("1", "Chai"), New LookUpValue("2", "Chang"), _ 
				New LookUpValue("3", "Aniseed Syrup") })

		' Add the parameter to the report's collection,
		' and filter the report based on the parameter's value.
		Me.Parameters.Add(parameter1)
		Me.FilterString = "[ProductID] = ?parameterProduct"

		' Display the current parameter value in the report.
		Dim label As New XRLabel()
		Me.Detail.Controls.Add(label)
		label.DataBindings.Add(New XRBinding(parameter1, "Text", ""))
		label.LocationFloat = New DevExpress.Utils.PointFloat(377.0833F, 10.00001F)

		' Pass a value to the parameter and publish the report.
		parameter1.Value = 1
		Me.RequestParameters = False
	End Sub
End Class
#End Region ' #Code
End Namespace
