
// 選取另一個父分類時取消選擇底下子分類
$("input[name='ParentCategory']").change(function () {
    $(".ChildCategoryCheckbox").prop("checked", false);
});


// 初始化圖示狀態
//function InitHeartIcon(button) {
//    var ItemID = button.getAttribute('data-ProductID');
//    console.log(ItemID);
//    var Icon = document.getElementById("ModalHeartIcon_" + item.ProductID);
//    var IconSet = Icon.querySelector('i');
//    var ItemMyHeart = button.getAttribute('data-MyHeart');
//    console.log(IconSet);
//    console.log(ItemMyHeart);

//    if (ItemMyHeart == 'true') {
//        // 如果 data-MyHeart 為 true，顯示為已加入最愛
//        IconSet.classList.remove('bi-heart');
//        IconSet.classList.add('bi-heart-fill');
//    } else {
//        // 如果 data-MyHeart 為 false，顯示為空心心形
//        IconSet.classList.remove('bi-heart-fill');
//        IconSet.classList.add('bi-heart');
//    }
//}

// 加入我的最愛
function HeartIconChange(button) {
    console.log(button);

    var ItemID = button.getAttribute('data-ProductID');
    var ItemMyHeart = button.getAttribute('data-MyHeart');
    //console.log (ItemID);
    //console.log(ItemMyHeart);

    var Icon = document.getElementById('ModalHeartIcon_' + ItemID);
    var Modal = new bootstrap.Modal(document.getElementById('HeartModal_' + ItemID));
    var ModalMessage = document.getElementById('HeartModalMessage_' + ItemID);
    //console.log(Icon);
    //console.log(Modal);
    //console.log(ModalMessage);

    if (ItemMyHeart == 'true') {

        Icon.classList.remove('bi-heart-fill');
        Icon.classList.add('bi-heart');
        button.setAttribute('data-MyHeart', 'false');
        console.log(button);
        ModalMessage.innerHTML = "已從我的最愛移除";
    } else {
        Icon.classList.remove('bi-heart');
        Icon.classList.add('bi-heart-fill');
        button.setAttribute('data-MyHeart', 'true');
        console.log(button);
        ModalMessage.innerHTML = "已加入我的最愛";
    }

    Modal.show();
    setTimeout(function () {
        Modal.hide();
    }, 3000);
}




var FooterImages = [
    document.getElementById("ModelFooterProductImage01"),
    document.getElementById("ModelFooterProductImage02"),
    document.getElementById("ModelFooterProductImage03")
];

var BodyImage = document.getElementById("ModelBodyProductImage");

FooterImages.forEach(function (item) {
    item.addEventListener('click', function () {
        BodyImage.src = `/image/${item.id}.jpg`;
    });
});


// 購物車localstorage傳送資料用
function AddToCart(button) {
    console.log(button)
    // 從按鈕的 data-* 屬性中獲取商品資料
    ItemID = button.getAttribute('data-ProductID');
    ItemName = button.getAttribute('data-Name');
    ItemPrice = button.getAttribute('data-Price');
    ItemDiscount = button.getAttribute('data-Discount');
    ItemImage = button.getAttribute('data-Image');
    ItemStock = button.getAttribute('data-Stock');

    // 檢查 localStorage 是否已有購物車
    let Cart = JSON.parse(localStorage.getItem("Cart")) || [];

    // 檢查是否已經有此商品，若有則更新數量，若沒有則新增
    let existingItem = Cart.find(Item => Item.ID === ItemID);
    if (existingItem) {
        existingItem.Quantity += 1; // 增加數量
    } else {
        Cart.push({
            ID: ItemID,
            Name: ItemName,
            Price: ItemPrice,
            Discount: ItemDiscount,
            Image: ItemImage,
            Stock: ItemStock,
            Quantity: 1
        });
    }

    // 將更新後的購物車儲存在 localStorage
    localStorage.setItem("Cart", JSON.stringify(Cart));

    // 這會顯示儲存的字串資料
    let cartData = localStorage.getItem("Cart");
    console.log(cartData);
    let parsedCart = JSON.parse(cartData);  // 將字串解析回物件
    console.log(parsedCart);


    alert("商品已加入購物車！");
}
