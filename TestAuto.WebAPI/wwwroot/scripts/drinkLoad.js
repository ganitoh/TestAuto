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
    var contentDiv = document.getElementById("drink-section");
    drinksData.forEach(drink => {
        //create elements
        var div = document.createElement('div');
        var img = document.createElement('img');
        var button = document.createElement('button');
        var p = document.createElement('p');

        button.textContent = 'Добавить';
        button.onclick = () => { payDrink(drink.id);}
        img.src = drink.relativePathPicture;
        img.alt = 'напиток';
        p.textContent = drink.name;

        div.appendChild(p);
        div.appendChild(img);
        div.appendChild(button);

        contentDiv.appendChild(div);
    });
}

async function payDrink(drinkId){
    await fetch(`/user/pay?drinkId=${drinkId}`,{
        method : 'GET',
        headers: {"Accept" : "application/json"}
    }).then(async (response) => {
        if (response.ok) {
            var responseData = await response.json();
            alert(`ваша сдача ${response.change}`)
        }
    });
}