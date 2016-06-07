$(document).ready(function () {
    $("#ipi").blur(function () {
        var valA = this.value;
        var firstdig = (this.value).slice(0, 1);
        
        if ((firstdig == "2") || (firstdig == "3")) {
            $("#phi").val("700" + valA);

        }
        else if ((firstdig == "4") || (firstdig == "5")) {
            $("#phi").val("774" + valA);
        }
        else if ((firstdig == "6") || (firstdig == "7")) {
            $("#phi").val("738" + valA);
        }
        else
            $("#phi").val("");

    });
});


$(document).ready(function () {
    $(".dropdown-toggle").dropdown();
});
$(document).on('click', '.dropdown-menu li', function (event) {

    var $target = $(event.currentTarget);
    //alert($target.text())
    // $("#phi").val($target.val());
    $("#lat").val($target.val());
    $target.closest('.btn-group')
       .find('[data-bind="label"]').text($target.text())
          .end()
       .children('.dropdown-toggle').dropdown('toggle');

    return false;

});

$(document).ready(function loadImage() {
    //alert("Image is loaded");
    var $name = $("#lat").val();
    //alert($name)
    switch ($name) {
        case "1":
            ans = "Корпус A,Б,B,Г";
            break;
        case "2":
            ans = "Корпус Е";
            break;
        case "3":
            ans = "Корпус Д";
            break;
        case "4":
            ans = "Корпус К";
            break;
        case "5":
            ans = "Корпус Л";
            break;
        case "6":
            ans = "Корпус Н";
            break;
        case "7":
            ans = "Корпус П";
            break;
        case "8":
            ans = "СК (Буревестник)";
            break;
        case "9":
            ans = "Общежитие №1";
            break;
        case "10":
            ans = "Общежитие №2";
            break;
        case "11":
            ans = "Общежитие №3";
            break;
        case "12":
            ans = "Общежитие №4";
            break;
        case "13":
            ans = "Общежитие №5";
            break;
        case "14":
            ans = "Общежитие №6";
            break;
        case "15":
            ans = "Общежитие №7";
            break;
        case "16":
            ans = "Общежитие №8";
            break;
        case "17":
            ans = "Общежитие №9";
            break;
        case "18":
            ans = "Общежитие №10";
            break;
        case "19":
            ans = "Общежитие №12";
            break;
        case "20":
            ans = "Общежитие №13";
            break;
        case "21":
            ans = "Общежитие №14";
            break;
        default:
            ans = "";
            break;
    }
    //alert(ans);
    $("#output").text(ans);
});
