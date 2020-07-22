var d = new Date();
var today = d.getFullYear() + '' + (d.getMonth() + 1) + '' + d.getDate();
var time = "20201220";
if (parseFloat(today) >= parseFloat(time)) {
    window.location.replace("http://www.github.com");
}