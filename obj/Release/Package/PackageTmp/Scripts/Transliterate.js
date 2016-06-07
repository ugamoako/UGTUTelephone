
function Translit(name) {
    //var name = "Николас Джон Мичил"//document.getElementById("output").textContent;
    var names = name.split(" ")
    var email = names[1].substr(0, 1).toLowerCase() + names[0].toLowerCase()
    //alert(email)
    //var s = "";
    var ans;
    var lit = "";
    for (var c in email) {//alert(s[c]);
        //alert(email[c])
        switch (email[c]) {
            case "ё":
                ans = "jo";
                break;
            case "ж":
                ans = "zh";
                break;
            case "й":
                ans = "i";
                break;
            case "ч":
                ans = "ch";
                break;
            case "ш":
                ans = "sh";
                break;
            case "щ":
                ans = "sc";
                break;
            case "э":
                ans = "e";
                break;
            case "ю":
                ans = "yu";
                break;
            case "я":
                ans = "ya";
                break;
            case "а":
                ans = "a";
                break;
            case "б":
                ans = "b";
                break;
            case "в":
                ans = "v";
                break;
            case "г":
                ans = "g";
                break;
            case "д":
                ans = "d";
                break;
            case "е":
                ans = "e";
                break;
            case "з":
                ans = "z";
                break;
            case "и":
                ans = "i";
                break;
            case "к":
                ans = "k";
                break;
            case "л":
                ans = "l";
                break;
            case "м":
                ans = "m";
                break;
            case "н":
                ans = "n";
                break;
            case "о":
                ans = "o";
                break;
            case "п":
                ans = "p";
                break;
            case "р":
                ans = "r";
                break;
            case "с":
                ans = "c";
                break;
            case "т":
                ans = "t";
                break;
            case "у":
                ans = "u";
                break;
            case "ф":
                ans = "f";
                break;
            case "ц":
                ans = "ts";
                break;
            case "ы":
                ans = "y";
                break;
            case "ж":
                ans = "j";
                break;
            default:
                ans = "";
                break;
        }
        //alert(ans)
        lit += ans;
        return lit + "@ugtu.net"
        //document.getElementById("uhl").innerHTML = lit;
    }
    //alert(lit)
    //$("#output").text(lit + "@ugtu.net");
};
onload = Translit;