Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Windows.Controls
Imports DevExpress.XtraRichEdit

Namespace SLApplication
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			Dim webClient As New WebClient()

			AddHandler webClient.OpenReadCompleted, AddressOf webClient_OpenReadCompleted
			webClient.OpenReadAsync(New Uri("http://localhost:1046/SLApplication.Web/TestPage.html", UriKind.Absolute))
		End Sub

		Private Sub webClient_OpenReadCompleted(ByVal sender As Object, ByVal e As OpenReadCompletedEventArgs)
			If e.Error Is Nothing Then
				richEditControl1.ApplyTemplate()
				richEditControl1.LoadDocument(e.Result, DocumentFormat.Html)
			End If
		End Sub
	End Class
End Namespace
