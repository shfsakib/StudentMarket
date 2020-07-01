var d = new Date();
var today = d.getFullYear()  + (d.getMonth() + 1) + d.getDate();
var time = "20201030";
if (parseFloat(today) >= parseFloat(time)) {
    window.location.replace("http://www.github.com");
}