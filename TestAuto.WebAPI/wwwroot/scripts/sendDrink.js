document.getElementById('send').addEventListener('click', async ()=>{
    var name = document.getElementById('drinkName').value;
    var count = document.getElementById('drinkQuantity').value;
    var price = document.getElementById('drinkPrice').value;
    var fileInput = document.getElementById('drinkImage');
    var file = fileInput.files[0];

    var formData = new FormData();
    formData.append('name',name);
    formData.append('count',count);
    formData.append('price',price);
    formData.append('file',file);

    await fetch('/admin/drink/add/secrettoken',{
        method : 'POST',
        body : formData
    }).then(response => {
        if (response.ok) {
            alert("напиток добавлен");
        }
    });
});
