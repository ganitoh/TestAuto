async function insertCoin(denominationCoin){
    var response = await fetch(`/user/deposit?denominationCoin=${denominationCoin}`,{
        method : 'GET'
    });

    if(response.ok){
        await showBalance();               
    }
}

async function showBalance(){
    await fetch('/user/balance',{
        method : 'GET'}).then(async (response) =>{
            if (response.ok) {
                var responseBalance = await response.json();
                document.getElementById('totalAmount').innerText = `Баланс: ${responseBalance.balance} руб.`;
            }
        }); 
} 