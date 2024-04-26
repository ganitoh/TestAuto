document.addEventListener("DOMContentLoaded",async () =>{
    var response = await fetch("/drink/all-by-dispenser?dispenserId=1",{
        method:"GET",
        headers: {"Accept" : "application/json"}
    });

    if (response.ok) {
        const drinksData = await response.json();
        loadDrinkData(drinksData);
    }
});

 function loadDrinkData(drinksData){
    var contentDiv = document.getElementById("drinks");
    drinksData.forEach(drink => {
        //create elements
        var div = document.createElement('div');
        var img = document.createElement('img');
        var button = document.createElement('button');
        var pname = document.createElement('p');
        var pInputName = document.createElement('p');
        var countInput = document.createElement('input');
        
        pInputName.textContent = 'колличество';
        countInput.type = 'number';
        button.textContent = 'Добавить';
        button.onclick = async () => 
        {
            var count = countInput.value;
            await updateDrinkCount(count,drink.id);
        }
        img.src = drink.relativePathPicture;
        img.alt = 'напиток';
        pname.textContent = drink.name;

        div.appendChild(pname);
        div.appendChild(img);
        div.appendChild(pInputName);
        div.appendChild(countInput);
        div.appendChild(button);

        contentDiv.appendChild(div);
    });
}

async function updateDrinkCount(count,drinkId){
    await fetch('/admin/drink/update-count/secrettoken',{
        method: 'POST',
        headers : {'Content-Type' : 'application/json'},
        body : JSON.stringify({
            drinkId:drinkId,
            count: count
        })
    }).then(respose => {
        if (respose.ok) {
            alert('успешно');
        }
    });
}
