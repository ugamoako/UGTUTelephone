// submits form upon selecting a value
var submitAutocompleteForm = function (event, ui) {
    var $input = $(this); // the HTML element (Textbox)

    // selected value
    $input.val(ui.item.label); // ui.item.label = the label value (product)
    //window.location.href = Html.BeginForm("Index", "Uptodate", FormMethod.Get)
    window.location.href = "/DeptEmploes/SearchID?search=" + ui.item.value;
};

$(function () {
    $("#txtSearch").autocomplete({
        source: function (request, response) {
            var param = $('#txtSearch').val();
            $.ajax({
                url: "/DeptEmploes/GetAll",
                data: JSON.stringify({ 'term': param }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data, function (item) {
                        if (item.Employee == null) {
                            return { label: item.DepartmentName, value: item.ID };
                        }
                        else {
                            return { label: item.DepartmentName + "-" + item.Employee, value: item.ID };
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }

            });

        },
        minLength: 3,
        select: submitAutocompleteForm
        //select: function (event, ui) {
        //onItemSelect(ui.item.value);
        //messages: {noResults:"", results:""}
        //minLength: 2//minLength as 2, it means when ever user enter 2 character in TextBox the AutoComplete method will fire and get its source data.
        //}
    });
    messages: { noResults: "No result" }
});
$("#txtSearch").click(function () {
    $(this).select();
});