/*
检查浏览器是否支持HTML5 BY NEILREN 2015年7月24日13:10:46
*/
function h5alert() {
    if (!window.applicationCache) {
        //浏览器不支持HTML5
        var h5alert = document.getElementById("h5alert");
        if (getCookie('h5alertgo') == "") {
            //没点击过继续打开，那么拦截提示
            h5alert.style.display = "block";
        }
    }
}
function h5alertgo() {
    var h5alert = document.getElementById("h5alert");
    setCookie('h5alertgo', 'h5alertgo', 365);
    h5alert.style.display = "none";
}
function setCookie(c_name, value, expiredays) {
    var exdate = new Date()
    exdate.setDate(exdate.getDate() + expiredays)
    document.cookie = c_name + "=" + escape(value) +
    ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
}
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return ""
}