function TogglePaymentMethod() {
    // 取得結帳方式點擊事件
    var PaymentSelected = {
        AtmLinepay: document.getElementById('Atm').checked || document.getElementById('Linepay').checked,
        Seveneleven: document.getElementById('Seveneleven').checked,
        Familymart: document.getElementById('Familymart').checked
    };
    // 取得取貨方式所有事件
    var Elements = {
        SevenElevenPickup: document.getElementById('SevenelevenPickup'),
        FamilyMartPickup: document.getElementById('FamilymartPickup'),
        HomeDeliveryPickup: document.getElementById('HomeDeliveryPickup'),

        SevenElevenStoreBtn: document.getElementById('SevenelevenPickupStore'),
        FamilyMartStoreBtn: document.getElementById('FamilymartPickupStore'),

        HomeDeliveryName: document.getElementById('HomeDeliveryName'),
        HomeDeliveryPhone: document.getElementById('HomeDeliveryPhone'),
        HomeDeliveryAddress: document.getElementById('HomeDeliveryAddress')
    };

    // 重置所有事件
    Elements.SevenElevenPickup.disabled =
        Elements.FamilyMartPickup.disabled =
        Elements.HomeDeliveryPickup.disabled =

        Elements.SevenElevenStoreBtn.disabled =
        Elements.FamilyMartStoreBtn.disabled =
        Elements.HomeDeliveryName.disabled =
        Elements.HomeDeliveryPhone.disabled =
        Elements.HomeDeliveryAddress.disabled =
        true;

    // 事件控制
    if (PaymentSelected.AtmLinepay) {
        Elements.SevenElevenPickup.checked =
            Elements.FamilyMartPickup.checked =
            Elements.HomeDeliveryPickup.disabled =
            Elements.HomeDeliveryName.disabled =
            Elements.HomeDeliveryPhone.disabled =
            Elements.HomeDeliveryAddress.disabled =
            false;

        Elements.HomeDeliveryPickup.checked =
            true

    } else if (PaymentSelected.Seveneleven) {
        Elements.FamilyMartPickup.checked =
            Elements.HomeDeliveryPickup.checked =
            Elements.SevenElevenPickup.disabled =
            Elements.SevenElevenStoreBtn.disabled =
            false;

        Elements.SevenElevenPickup.checked =
            true;

    } else if (PaymentSelected.Familymart) {
        Elements.SevenElevenPickup.checked =
            Elements.HomeDeliveryPickup.checked =
            Elements.FamilyMartPickup.disabled =
            Elements.FamilyMartStoreBtn.disabled =
            false;

        Elements.FamilyMartPickup.checked =
            true;
    }
}