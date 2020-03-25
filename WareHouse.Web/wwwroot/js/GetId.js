function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    //console.log(window.location.search);//?id=2
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}
function GetId() {
    var reg = new RegExp("(^|&)id=([^&]*)(&|$)");
    //console.log(window.location.search);//?id=2
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}