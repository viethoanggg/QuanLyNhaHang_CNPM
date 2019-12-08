
function ChonLoaiMonAn() {
    var xhttp = new XMLHttpRequest();
    var IdBanAn = document.getElementById("idba").value;
    var IdLoaiMonAn = document.getElementById("ChonLoaiMonAn").value;
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("c").innerHTML = this.response;

        }
    };
    xhttp.open("GET", "/BanAn/GetLoaiMonAn?IdBanAn=" + IdBanAn + "&IdLoaiMonAn=" + IdLoaiMonAn, true);
    xhttp.send();
}

function ThemCTHD(IdMonAn, IdSoLuong) {
    var xhttp = new XMLHttpRequest();
    var SoLuong = document.getElementById(IdSoLuong).value;
    var IdHoaDon = document.getElementById("idhd").value;
    var IdBanAn = document.getElementById("idba").value;
    var IdLoaiMonAn = document.getElementById("ChonLoaiMonAn").value;
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("show_cthd").innerHTML = this.response;
            setTimeout(function () {
                var s = document.getElementById("laythanhtoan").value;
                document.getElementById("thanhtien").value = s;
            }, 200);


        }
    };
    xhttp.open("GET", "/BanAn/ThemCTHD?IdHoaDon=" + IdHoaDon + "&IdBanAn=" + IdBanAn + "&IdLoaiMonAn=" + IdLoaiMonAn + "&IdMonAn=" + IdMonAn + "&SoLuong=" + SoLuong, true);
    xhttp.send();

}

function TruSLTrongListMonAn(id) {
    var s = document.getElementById(id).value;
    var sl = Number(s);
    sl = sl - 1;
    if (sl < 1)
        sl = 1;
    document.getElementById(id).value = sl;
}
function CongSLTrongListMonAn(id) {
    var s = document.getElementById(id).value;
    var sl = Number(s);
    sl = sl + 1;
    if (sl > 10)
        sl = 10;
    document.getElementById(id).value = sl;
}

function TruSLTrongCTHD(idSoLuong, IdHoaDon, IdMonAn, idGiaMonAn, idDonGiaCTHD) {
    var s = document.getElementById(idSoLuong).value;
    var sl = Number(s);
    sl = sl - 1;
    if (sl < 1)
        sl = 1;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById(idSoLuong).value = sl;
            var giaMonAn = document.getElementById(idGiaMonAn).innerHTML;
            document.getElementById(idDonGiaCTHD).innerHTML = sl * Number(giaMonAn);

            document.getElementById("laythanhtoan").value = this.responseText;
            document.getElementById("thanhtien").value = this.responseText;
        }
    };
    xhttp.open("GET", "/BanAn/CapNhatSoLuongCTHD?IdHoaDon=" + IdHoaDon + "&IdMonAn=" + IdMonAn + "&SoLuong=" + sl, true);
    xhttp.send();

}

function CongSLTrongCTHD(idSoLuong, IdHoaDon, IdMonAn, idGiaMonAn, idDonGiaCTHD) {
    var s = document.getElementById(idSoLuong).value;
    var sl = Number(s);
    sl = sl + 1;
    if (sl > 10)
        sl = 10;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById(idSoLuong).value = sl;
            var giaMonAn = document.getElementById(idGiaMonAn).innerHTML;
            document.getElementById(idDonGiaCTHD).innerHTML = sl * Number(giaMonAn);

            document.getElementById("laythanhtoan").value = this.responseText;
            document.getElementById("thanhtien").value = this.responseText;
        }
    };
    xhttp.open("GET", "/BanAn/CapNhatSoLuongCTHD?IdHoaDon=" + IdHoaDon + "&IdMonAn=" + IdMonAn + "&SoLuong=" + sl, true);
    xhttp.send();
}

function XoaCTHD(IdHoaDon, IdMonAn) {
    var xhttp = new XMLHttpRequest();
    var IdHoaDon = document.getElementById("idhd").value;
    var IdBanAn = document.getElementById("idba").value;
    var IdLoaiMonAn = document.getElementById("ChonLoaiMonAn").value;
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("show_cthd").innerHTML = this.response;
            var s = document.getElementById("laythanhtoan").value;
            document.getElementById("thanhtien").value = s;

        }
    };
    xhttp.open("GET", "/BanAn/XoaCTHD?IdHoaDon=" + IdHoaDon + "&IdBanAn=" + IdBanAn + "&IdLoaiMonAn=" + IdLoaiMonAn + "&IdMonAn=" + IdMonAn, true);
    xhttp.send();

}