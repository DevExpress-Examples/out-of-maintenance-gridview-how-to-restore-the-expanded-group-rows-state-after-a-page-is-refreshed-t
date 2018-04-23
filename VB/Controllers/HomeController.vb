Imports System.Web.Mvc

Namespace GridViewExpandedGroupRowsStateMvc
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial(ByVal customAction As String) As ActionResult
			ViewData("actionToPerform") = customAction
			Return PartialView()
		End Function
	End Class
End Namespace