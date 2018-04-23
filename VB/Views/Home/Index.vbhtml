<script type="text/javascript">
    function OnSave(s, e) {
        GridView.PerformCallback({ customAction: 'Save' });
    }
    function OnLoad(s, e) {
        GridView.PerformCallback({ customAction: 'Load' });
    }
</script>

@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnSave"
            settings.Text = "Save"
            settings.ClientSideEvents.Click = "OnSave"
    End Sub).GetHtml()

@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnLoad"
            settings.Text = "Load"
            settings.ClientSideEvents.Click = "OnLoad"
    End Sub).GetHtml()

@Html.Action("GridViewPartial")