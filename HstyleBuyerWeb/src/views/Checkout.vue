<!-- checkout.vue -->
<template>
    <div class="container mt-3">
        <div class="row">
            <div class="col-md-12">
                <h4>我的購物車</h4>
                <hr>
                <div v-for="item in products.cartItems" class="card mb-3">
                    <div class="row g-0">
                        <div class="col-md-3">
                            <img :src="item.image" alt="圖片已失效">
                        </div>
                        <div class="col-md-9">
                            <div class="card-body">
                                <h5 class="card-title">{{ item.productName }}</h5>
                                <p class="card-text">{{ item.color + item.size }}</p>
                                <div class="btn-group" role="group">
                                    <button type="button" class="btn btn-outline-secondary btn-s"
                                        @click="minusItem(item.specId)">
                                        <i class="fa-solid fa-minus  fa-xs"></i>
                                    </button>
                                    <button type="button" class="btn btn-outline-secondary btn-s">
                                        {{ item.quantity }}
                                    </button>
                                    <button type="button" class="btn btn-outline-secondary btn-s"
                                        @click="addItem(item.specId)">
                                        <i class="fa-solid fa-plus  fa-xs"></i>
                                    </button>
                                </div>
                                <p class="card-text">小計: {{ item.unitPrice * item.quantity }}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <h4>收件與付款資訊</h4>
                <hr>

                <div class="mb-3">
                    <label for="name" class="form-label">姓名</label>
                    <input v-model="shipName" type="text" class="form-control" id="name" placeholder="請輸入姓名">
                </div>
                <div class="mb-3">
                    <label for="address" class="form-label">地址</label>
                    <input v-model="shipAddress" type="text" class="form-control" id="address" placeholder="請輸入地址">
                </div>
                <div class="mb-3">
                    <label for="phone" class="form-label">電話</label>
                    <input v-model="shipPhone" type="text" class="form-control" id="phone" placeholder="請輸入電話號碼">
                </div>
                <div class="mb-3">
                    <label for="payment" class="form-label">付款方式</label>
                    <select v-model="payment" class="form-select" aria-label="Select payment method" id="payment">
                        <option selected>選擇付款方式</option>
                        <option value="信用卡">信用卡</option>
                        <option value="Paypal">PayPal</option>
                    </select>
                </div>

            </div>
            <div class="col-md-6">
                <h5>訂單摘要</h5>
                <hr>
                <p>商品金額: {{ products.total }}</p>
                <p>運費: NT$0</p>
                <p>使用H幣(目前有{{ H_Coin }}，最高可使用{{ coinUseLimit }}):</p><input v-model="discount" type="text" name="" id="">
                <h5>總金額: NT${{ totalIncludeHcoin }}</h5>
                <button @click="checkout" type="button" class="btn btn-dark">結帳</button>
            </div>
        </div>
    </div>
</template>
  
<script setup>
import { ref, onMounted, computed, reactive } from "vue";
import axios from "axios";

//呈現購物車
const products = ref([]);
const getCartInfo = async () => {
    await axios.get("https://localhost:7243/api/Cart")
        .then(response => { products.value = response.data; })
        .catch(error => { console.log(error); });
}

const addItem = async (specId) => {
    await axios.post(`https://localhost:7243/api/Cart/${specId}`)
        .then(response => {
            getCartInfo();
        })
        .catch(error => { console.log(error); });
}
const minusItem = async (specId) => {
    await axios.delete(`https://localhost:7243/api/Cart/${specId}`)
        .then(response => {
            getCartInfo();
        })
        .catch(error => { console.log(error); });
}

//綁定收件、收費資料
const shipName = ref("");
const shipAddress = ref("");
const shipPhone = ref("");
const payment = ref("Paypal")
const discount = ref(0)
const totalIncludeHcoin = computed(() => {
    return products.value.total - discount.value;
});

//結帳
const H_Coin = ref(0);
const getCoin = async () => {
    await axios.get('https://localhost:7243/api/HCoin/TotalHCoin/1')
        .then(response => {
            H_Coin.value = response.data;
        })
}
const coinUseLimit = computed(() => {
    return parseInt(products.value.total * 0.2)
})
const checkout = async () => {
    await axios.post(`https://localhost:7243/api/Cart/Checkout`, {
        payment: shipName.value,
        shipVia: "黑貓",//todo。運送方式改成後台管理頁面填寫
        freight: 0,//todo，考慮運費拿掉全部免運
        discount: discount.value,
        shipName: shipName.value,
        shipAddress: shipAddress.value,
        shipPhone: shipPhone.value
    })
        .then(response => {
            axios.post(`https://localhost:7243/api/Paypal/${response.data}`)
                .then(response => {
                    window.location = response.data.paypalLink
                })
                .catch(error => { console.log(error); });
        })
        .catch(error => { console.log(error); });
}

onMounted(() => {
    getCartInfo();
    getCoin();
});

</script>
<style>
.card img {
    width: 200px;
    height: 200px;
}
</style>