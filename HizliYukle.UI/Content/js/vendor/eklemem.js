//function DilDegis(gonder) {
//    //location.href = "@Url.Action('DilDegistir', 'Home', new { dil='en', returnURL=Request.RawUrl }))" + $(Gonder).Val(),
//    alert.gonder("sdgpıop");
//}
function diller(kim,r) {

    location.href = '/Home/DilDegistir?dil=' + $(kim).val() + '&returnURL=' + r;
}
