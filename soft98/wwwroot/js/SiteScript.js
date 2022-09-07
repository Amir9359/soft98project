function OpenNav() {
    document.getElementById("MySide").style.width = "250px";
    document.getElementById("MainMobile").style.marginRight = "250px";
    document.getElementById("openbtn").style.display = "none";
}
function CloseNav() {
    document.getElementById("MySide").style.width = "0";
    document.getElementById("MainMobile").style.marginRight = "0";
    document.getElementById("openbtn").style.display = "block";
}

var dropdown = document.getElementsByClassName("dropdown-btn");
for (var i = 0; i < dropdown.length; i++) {
    dropdown[i].addEventListener("click", function () {
        var dropdownContent = this.nextElementSibling;

        if (dropdownContent.style.display === "inline-block") {
            dropdownContent.style.display = "none";
        } else {
            dropdownContent.style.display = "inline-block";
        }
    })
}

function openPage(page) {
    var tabContents = document.getElementsByClassName("tabcontent");
    for (var i = 0; i < tabContents.length; i++) {
        tabContents[i].style.display = "none";
    }
    document.getElementById(page).style.display = "block";


}
document.getElementById("defaultopen").click();
document.getElementById("defaultopen").focus();

document.getElementById('myInputSearch').addEventListener('keypress',
    function (event) {
        if (event.keyCode == 13) {
            var myId = document.getElementById('myInputSearch').value;

            window.open("/Home/Search/" + myId);
        }
    })

 