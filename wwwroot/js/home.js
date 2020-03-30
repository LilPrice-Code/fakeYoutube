console.log("Home Page")

var book = document.getElementById("container")

fetch("api/YouItem")
.then(data=>data.json())
.then(data=>{
    data.forEach(vid => {
    var re_EL = document.createElement("div")
    re_EL.innerHTML=`<div class="pages">
    <div class="pics"> <p>${vid.name}</p>
    <video width="320"  height="240" controls>  <source src="${vid.video}" type="video/mp4"></video></div>
    <div class ="info">
    <p>${video.pubDate}</p>
    <button onclick="window.location.href = 'detail.html?Did=${vid.id}'" >Watch Video</button>
    </div>`
    book.append(re_EL)

    });
  
})