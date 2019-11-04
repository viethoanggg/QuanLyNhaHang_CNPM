var thucdon=
{
    init : function(){
        thucdon.registerEvents();
    },
    registerEvents : function()
    {
        $('#ChonLoaiMonAn').off('click').on('change', function (e) {
            e.preventDefault;
            var trang = $(this);
            var idLoaii = trang.val();
            $.ajax({
                url: "ListThucDon",
                data: { idLoai: idLoaii },
                typeTpye: "json",
                type:"POST",
                success: function (response) {
                    var js = response;
                    var l = JSON.parse(js);
                    var s="<tr>"+"<tr><th> Tên món ăn </th><th> Loại </th><th> Giá</th></tr>";

                    for (var x in l) {
                        var gg = JSON.parse(x);
                        s += "<td>"+gg.Ten+"</td>";
                        s += "<td>s</td>";
                        s += "<td>s</td>";
                        s += "</tr>";
                    }
                    $('#phantrang_thucdon_banghang').html(s);
                }
            });
        });
    }
}
thucdon.init();