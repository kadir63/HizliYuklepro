function ajaxGetir() {
    //$.ajax({
    //    url: "/AJAX/Index",
    //    type: "GET",
    //    data: { "adSoyad": $("#iAdSoyad").val(), "yas": $(".iYas").val() },
    //    success: function (veri) {
    //        $(".pIcerik").html(veri);
    //    },
    //    error: function (hata) { alert(hata.responseText) }
    //});
    $.ajax({
        url: "/AJAX/Sehirler",
        type: "GET",
        success: function (veri) {
            $.each(veri, function (index, item) {
                //$(".sehir").append("<option>" + item + "</option>");
                $(".sehir").append("<option value='" + item.ID + "'>" + item.Title + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
}
function IlceGetir(tiklayan) {
    $.ajax({
        url: "/AJAX/Ilceler",
        type: "GET",
        data: { "Plaka": $(tiklayan).val() },
        success: function (veri) {
            $(".ilceler").empty();
            $(".ilceler").append("<option value='0'>İlçe Seçiniz</option>");
            $.each(veri, function (index, item) {
                $(".ilceler").append("<option value='" + item.ID + "'>" + item.Title + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
}
function mahalleGetir(tiklayan) {
    $.ajax({
        url: "/AJAX/Mahalleler",
        type: "GET",
        data: { "ilceID": $(tiklayan).val() },
        success: function (veri) {
            $(".mahalleler").empty();
            $.each(veri, function (index, item) {
                $(".mahalleler").append("<option value='" + item.ID + "'>" + item.Ad + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
}