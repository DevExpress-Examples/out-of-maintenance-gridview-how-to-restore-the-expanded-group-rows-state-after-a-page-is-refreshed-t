@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "GridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
            settings.KeyFieldName = "OrderID"
            settings.Columns.Add("OrderID")
            settings.Columns.Add( _
                Sub(column)
                    column.FieldName = "CustomerID"
                    column.GroupIndex = 0
                    column.SortIndex = 0
                    column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            End Sub)
            settings.Columns.Add( _
                 Sub(column)
                     column.FieldName = "EmployeeID"
                     column.GroupIndex = 1
                     column.SortIndex = 1
                     column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
             End Sub)
            settings.Columns.Add("OrderDate")
            settings.Columns.Add("RequiredDate")
            settings.Columns.Add("ShippedDate")

            settings.BeforeGetCallbackResult = _
                Sub(s, e)
                    Dim grid As MVCxGridView = CType(s, MVCxGridView)
                    Dim states As New List(Of Integer)()

                    If "Save".Equals(ViewData("actionToPerform")) Then
                        For i As Int32 = 0 To grid.VisibleRowCount - 1
                            If grid.IsGroupRow(i) AndAlso grid.IsRowExpanded(i) Then
                                states.Add(i)
                            End If
                        Next i
                        Session("expandedRows") = states
                    ElseIf "Load".Equals(ViewData("actionToPerform")) Then
                        states = TryCast(Session("expandedRows"), List(Of Integer))
                        If states Is Nothing Then
                            Return
                        End If

                        grid.CollapseAll()
                        For Each index As Integer In states
                            grid.ExpandRow(index)
                        Next index
                    End If
            End Sub
    End Sub).Bind(NorthwindDataProvider.GetOrders()).GetHtml()