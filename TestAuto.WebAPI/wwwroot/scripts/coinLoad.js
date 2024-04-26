document.addEventListener('DOMContentLoaded',async ()=>{
    var response = await fetch('/coin/all-coins-dispenser?dispenserId=1',{
        method: 'GET'
    });

    if (response.ok) {
        var coinData = await response.json();
        blockedCoin(coinData);
    }
});

function blockedCoin(coinData){
    coinData.forEach(coin => {
        var denominationCoin = coin.denomination;
        if (coin.isBlock) {
            var coinAddButton = document.getElementById(`coin${denominationCoin}`);
            coinAddButton.style.background = 'red';
            coinAddButton.onclick = () => {alert('монета заблокирована')};
        }
    });
}
