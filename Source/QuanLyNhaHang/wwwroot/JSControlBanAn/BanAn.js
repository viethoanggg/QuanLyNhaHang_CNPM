function LocTrangThai(trangThai) {
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("IndexAjax").innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "/BanAn/IndexAjax?trangThai=" + trangThai + "&page=1");
    xhttp.send();
}