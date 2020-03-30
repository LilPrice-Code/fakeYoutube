console.log("AddPage")
function AddVideo(){
    console.log("Add Video")
    var date = new Date();
    var month = date.getMonth();
    month = month + 1;
    var day = date.getDate();
    var year = date.getFullYear();
    var hour = date.getHours();
    var min = date.getMinutes();
    if(min < 10){
        min = "0" + min
    }
    var time = `${month}/${day}/${year} ${hour}:${min}`
    console.log(time)
    fetch("api/YouItem",{
        method : "POST",
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body:JSON.stringify({
            name: document.getElementById("name").value,
            author: document.getElementById("video").value,
            pubDate: time,
        })
    })


    window.open("home.html", "_self")
}