var d = new Date();
var today = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();
var time = "2020/9/10";
if (today>=time) {
    window.location.replace("http://www.google.com");
}
