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
        var pName = document.createElement('p');
        var pPrice = document.createElement('p');

        button.textContent = 'купить';
        button.onclick = () => { payDrink(drink.id);}
        img.src = drink.relativePathPicture;
        img.alt = 'напиток';
        img.onclick = ()=>{payDrink(drink.id);}
        pName.textContent = drink.name;
        pPrice.textContent = `цена ${drink.price} руб.`

        div.appendChild(pName);
        div.appendChild(pPrice);
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
            var responseMessage = '';
            responseData.change.forEach(coin =>{ responseMessage += `${coin};` });
            alert(`ваша сдача ${responseMessage}`)
            await showBalance();
        }
        else{
            var responseMessage = await response.json();
            alert(`${responseMessage.message}`)
        }
    });
}
