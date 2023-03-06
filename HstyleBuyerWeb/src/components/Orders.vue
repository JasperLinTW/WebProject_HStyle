<template>
    <div class="container my-5">
        <div class="order-header border-bottom border-dark">
            <div class="row mb-2">
                <div class="col-1"></div>
                <div class="col-2">訂單編號</div>
                <div class="col-2">金額</div>
                <div class="col-2">日期</div>
                <div class="col-2">付款方式</div>
                <div class="col-1">狀態</div>
                <div class="col-2">幫助</div>
            </div>
        </div>
        <div v-for="(order, index) in orders" :key="order.orderId" class="accordion-item border-bottom my-4" id="accordionExample">
            <div class="row accordion-header px-0 pb-3">
                <div class="col-1"  data-bs-toggle="collapse">
                    <i v-if="selectProduct === index" @click="hideDetails(index)" class="fa-regular fa-square-minus"></i>
                    <i v-else @click="showDetails(index)" class="fa-regular fa-square-plus"></i>
                </div>
                <div class="col-2">{{ order.orderId }}</div>
                <div class="col-2">NT$ {{ order.total }}</div>
                <div class="col-2">{{ order.createdTime.slice(0, 10) }}</div>
                <div class="col-2">{{ order.payment }}</div>
                <div class="col-1">
                    <div v-if="order.statusId === 1">
                        <a :href="`https://www.sandbox.paypal.com/checkoutnow?token=${order.payInfo}`" class="alink">待付款</a>
                    </div>
                    <div v-else>
                        {{ order.status }}
                    </div> 
                
                </div>
                <div class="col-2">
                    <a>聯絡客服</a>
                </div>
            </div>
            <div class="accordion-collapse collapse show py-1 px-3" v-if="selectProduct === index">
                <div class="row bg-dark text-white font-weight-bold  py-2">
                    <div class="col-1"></div>
                    <div class="col-2">品名</div>
                    <div class="col-2">規格</div>
                    <div class="col-2">單價</div>
                    <div class="col-2">數量</div>
                    <div class="col-2">小計</div>
                    <div class="col-1"></div>
                </div>
                <div v-for="(product, index) in order.orderDetails" :key="index" class="row accordion-body border-start border-end py-3">
                    <div class="col-1"></div>
                    <div class="col-2">{{ product.productName }}</div>
                    <div class="col-2">{{ product.color }}</div>
                    <div class="col-2">{{ product.unitPrice }}</div>
                    <div class="col-2">{{ product.quantity }}</div>
                    <div class="col-2">{{ product.subTotal }}</div>
                    <div class="col-1">我要評論</div>
                </div>
                <div class="row order-item-footer py-1  border-start border-end border-bottom">
                    <div class="col-1"></div>
                    <div class="col-1">共 {{ order.orderDetails.length }} 件</div>
                    <div class="col-6"></div>
                    <div class="col-3">
                        <div class=" text-right">H幣折抵：{{ order.discount }}</div>
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
const selectProduct = ref("");
function showDetails(index) {
    // orders.value[index].showDetails = !orders.value[index].showDetails;
    selectProduct.value = index;
}
function hideDetails(index) {
    // orders.value[index].showDetails = !orders.value[index].showDetails;
    selectProduct.value = null;
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
.p-0 {
    padding: 0 !important;
}

.alink{
    text-decoration: none;
    color: #46a3ff;
    font-weight: bolder;
}

.alink:hover {
    text-decoration-line: underline;
}

.accordion-item {

    border: none;

}
</style>
  