<template>
    <div class="container my-5">
        <div class="order-header border-top border-bottom pt-2">
            <div class="row mb-2">
                <div class="col-1 text-center"></div>
                <div class="col-1 text-center">訂單編號</div>
                <div class="col-2 text-center">金額</div>
                <div class="col-2 text-center">日期</div>
                <div class="col-2 text-center">付款方式</div>
                <div class="col-1 text-center">狀態</div>
                <div class="col-2 text-center">幫助</div>
            </div>
        </div>
        <div class="accordion  accordion-flush" id="accordionExample">
            <div v-for="(order, index) in orders" :key="order.orderId" class="accordion-item">
                <div class="accordion-header row" :id="'heading' + index">
                    
                        <div class="col-1 text-center"><button class="accordion-button btn-order" type="button" data-bs-toggle="collapse"
                        :data-bs-target="'#collapse' + index" :class="{ 'collapsed': index !== -1 }" aria-expanded="false"
                        :aria-controls="'collapse' + index"></button></div>
                        <div class="col-1 text-center pt-2">{{ order.orderId }}</div>
                        <div class="col-2 text-center pt-2">NT$ {{ order.total }}</div>
                        <div class="col-2 text-center pt-2">{{ order.createdTime.slice(0, 10) }}</div>
                        <div class="col-2 text-center pt-2">{{ order.payment }}</div>
                        <div class="col-1 text-center pt-2 ps-1">
                            <div v-if="order.statusId === 1" @click.prevent="goToPay(order.payInfo)">
                                <a class="alink">待付款<i class="fa-solid fa-arrow-up-right-from-square fz-sm ps-2"></i></a>
                            </div>
                            <div v-else>
                                {{ order.status }}
                            </div>
                        </div>
                        <div class="col-2 pt-2 text-center">
                            <a>聯絡客服</a>
                        </div>
                    
                </div>
                <div :id="'collapse' + index" class="accordion-collapse collapse" :aria-labelledby="'heading' + index"
                    data-bs-parent="#accordionExample">
                    <div class="accordion-body">
                        <div class="row bg-dark text-white font-weight-bold  py-2">
                            <div class="col-1"></div>
                            <div class="col-2 text-center">品名</div>
                            <div class="col-2 text-center">規格</div>
                            <div class="col-2 text-center">單價</div>
                            <div class="col-2 text-center">數量</div>
                            <div class="col-2 text-center">小計</div>
                            <div class="col-1"></div>
                        </div>
                        <div v-for="(product, index) in     order.orderDetails" :key="index"
                            class="row accordion-body border-start border-end py-3 px-0">
                            <div class="col-1"></div>
                            <div class="col-2 text-center">{{ product.productName }}</div>
                            <div class="col-2 text-center">{{ product.color }}</div>
                            <div class="col-2 text-center">{{ product.unitPrice }}</div>
                            <div class="col-2 text-center">{{ product.quantity }}</div>
                            <div class="col-2 text-center">{{ product.subTotal }}</div>
                            <div class="col-1">我要評論</div>
                        </div>
                        <div class="row order-item-footer py-2 border ">
                            <div class="col-1"></div>
                            <div class="col-2  text-center">共 {{ order.orderDetails.length }} 件</div>
                            <div class="col-6"></div>
                            <div class="col-2 text-center">
                                H幣折抵：{{ order.discount }}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
  
  
<script setup>
import { onMounted, ref } from 'vue';
import axios from "axios";

const orders = ref([]);

const getOrdersInfo = async () => {
    await axios.get("https://localhost:7243/api/Order")
        .then(response => {
            orders.value = response.data;
            console.log(orders.value)
        })
        .catch(error => { console.log(error); });
}

function goToPay(token) {
    // 使用 window.location.href 跳轉到 PayPal 付款頁面
    window.location.href = `https://www.sandbox.paypal.com/checkoutnow?token=${token}`;
}

function timeFormat(date) {
    const year = date.getFullYear();
    const month = date.getMonth() + 1;
    const day = date.getDate();

    return `${year}-${month}-${day}`
}

function getReviewLink(orderId) {
    return `review/${orderId}`;
}

function getContactLink(orderId) {
    return `contact/${orderId}`;
}

onMounted(() => {
    getOrdersInfo();
});

</script>

<style scoped>
.fz-sm {
    font-size: 5pt;
    color: gray;
}

.alink {
    text-decoration: none;
    padding-left: 15pt;
    color: #46A3FF;
}

.accordion-item {
    border-top: none;
    border-radius: none;

}

.accordion {
    background-color: transparent;
    --bs-accordion-border-radius: 0%;
}

.accordion-button {
    --bs-accordion-btn-icon-width: 12pt;
}

.btn-order {
    background: none;
    color: #000;
    box-shadow: none;
}

.btn-order:focus {
    outline-color: none;
    box-shadow: none;
}
</style>
  