async function updateCountCoint(){
    var count = document.getElementById('coinQuantity').value;
    var denominationCoin = document.getElementById('coinType').value;

    await fetch('/admin/coin/update-count/secrettoken', {
        method : 'POST',
        headers : {"Content-Type" : "application/json"},
        body : JSON.stringify({
            denominationCoin: denominationCoin,
            count: count
        })
    }).then(respose => {
        if (respose.ok) {
            alert("количество изменено")
        }
    });
}