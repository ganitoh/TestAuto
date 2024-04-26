async function blockCoin(){
    var coinType = document.getElementById('blockcoinStatus').value
    var denominationCoin = document.getElementById('blockcoinType').value;

    if (coinType == 'active') {
        await fetch('/admin/coin/unblock/secrettoken',{
            method: 'POST',
            headers: {"Content-Type" : "application/json"},
            body : JSON.stringify({
                denominationCoin : denominationCoin
            })
        }).then(response => {
            if (response.ok) {
                alert('монета активна');
            }
        });
    } else if (coinType == 'blocked'){
        await fetch('/admin/coin/block/secrettoken',{
            method: 'POST',
            headers: {"Content-Type" : "application/json"},
            body : JSON.stringify({
                denominationCoin : denominationCoin
            })
        }).then(response => {
            if (response.ok) {
                alert('монета заблокирована');
            }
        });
    }
}