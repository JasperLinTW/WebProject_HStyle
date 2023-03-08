<!-- checkout.vue -->
<template>
  <div class="container mt-3">
    <div class="row">
      <div class="col-md-12 mb-3 cartContent">
        <div class="text-start border-bottom">
          <h5 class="fw-bold">購物車</h5>
        </div>
        <div v-for="item in products.cartItems" class="py-3 border-bottom row">
          <div class="col-md-12 d-flex align-items-center">
            <div class="">
              <div class="custom">
                <img :src="item.image" alt="圖片已失效" />
              </div>
            </div>
            <div class="ms-5">
              <span class="card-title"
                >{{ item.productName }}
                <span class="border-start ps-2"
                  >規格: {{ item.color + ", " + item.size }}</span
                >
              </span>
            </div>
            <div class="flex-grow-1 text-end pe-6">
              <div class="btn-group" role="group">
                <button
                  type="button"
                  class="btn btn-custom btn-outline-secondary btn-s"
                  @click="minusItem(item.specId)"
                >
                  <i class="fa-solid fa-minus fa-xs"></i>
                </button>
                <button
                  type="button"
                  class="btn btn-custom btn-outline-secondary btn-s quantity"
                >
                  {{ item.quantity }}
                </button>
                <button
                  type="button"
                  class="btn btn-custom btn-outline-secondary btn-s"
                  @click="addItem(item.specId)"
                >
                  <i class="fa-solid fa-plus fa-xs"></i>
                </button>
              </div>
            </div>
            <div class="ms-auto">
              <span>NT$ {{ item.unitPrice * item.quantity }}</span>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-7 mt-5">
        <div class="fz-12 fw-bold text-start border-bottom pb-1 mb-2">
          收件與付款資訊
        </div>
        <div class="my-4 d-flex justify-content-between">
          <label for="name" class="form-label fw-bold pe-3">姓名</label>
          <input
            v-model="shipName"
            type="text"
            class="textbox_ship flex-grow-1"
            id="name"
            placeholder="請輸入姓名"
          />
          <label for="phone" class="form-label fw-bold pe-3">電話</label>
          <input
            v-model="shipPhone"
            type="text"
            class="textbox_ship flex-grow-1"
            id="phone"
            placeholder="請輸入電話號碼"
          />
        </div>
        <div class="mb-4 d-flex justify-content-between">
          <label for="address" class="form-label fw-bold pe-3">地址</label>
          <input
            v-model="shipAddress"
            type="text"
            class="textbox_ship flex-grow-1"
            id="address"
            placeholder="請輸入地址"
          />
        </div>
        <div class="mb-3 d-flex justify-content-between">
          <label for="payment" class="form-label fw-bold pe-3">付款方式</label>
          <div class="flex-grow-1">
            <select
              v-model="payment"
              aria-label="Select payment method"
              id="payment"
            >
              <option value="">選擇付款方式</option>
              <option value="信用卡">信用卡</option>
              <option value="Paypal">PayPal</option>
            </select>
          </div>
        </div>
      </div>
      <div class="col-md-1"></div>
      <div class="col-md-4 mt-5">
        <div class="fz-12 fw-bold text-start border-bottom pb-1 mb-2">
          訂單摘要
        </div>
        <div class="d-flex justify-content-between pb-3">
          <div class="fw-bold">商品金額</div>
          <div class="pe-1">NT$ {{ products.total }}</div>
        </div>
        <div class="d-flex justify-content-between pb-3">
          <div class="fw-bold">運費</div>
          <div class="pe-1">NT$ 0</div>
        </div>
        <div class="d-flex justify-content-between pb-2">
          <div class="fw-bold">使用H幣</div>
          <input
            v-model="discount"
            type="text"
            class="textbox form-floating"
            name=""
            id=""
            placeholder="請輸入數量"
          />
        </div>
        <div class="fz-sm text-end pb-4">
          目前有{{ H_Coin }}枚，最高可使用{{ coinUseLimit }}枚
        </div>
        <div class="d-flex justify-content-between border-top py-4">
          <div class="fw-bold">總金額</div>
          <div>NT$ {{ totalIncludeHcoin }}</div>
        </div>
        <div class="text-end mt-1 mb-5">
          <button
            :disabled="progressing"
            @click="checkout"
            type="button"
            class="btn checkoutbtn"
          >
            提交訂單
          </button>
          <div id="result"></div>
        </div>
      </div>
    </div>
  </div>
  <div v-if="progressing" id="modal" class="modal">
    <div class="modal-content">
      <img
        class="loading"
        src="../assets/progressGif/loading.gif"
        alt="Loading..."
      />
    </div>
  </div>
</template>
  
<script setup>
import { ref, onMounted, computed, onBeforeMount } from "vue";
import axios from "axios";

//呈現購物車
const products = ref([]);
const getCartInfo = async () => {
  await axios
    .get("https://localhost:7243/api/Cart", { withCredentials: true })
    .then((response) => {
      products.value = response.data;
    })
    .catch((error) => {
      console.log(error);
    });
};

const addItem = async (specId) => {
  await axios
    .post(
      `https://localhost:7243/api/Cart/${specId}`,
      {},
      { withCredentials: true }
    )
    .then((response) => {
      getCartInfo();
    })
    .catch((error) => {
      console.log(error);
    });
};
const minusItem = async (specId) => {
  await axios
    .delete(`https://localhost:7243/api/Cart/${specId}`, {
      withCredentials: true,
    })
    .then((response) => {
      getCartInfo();
    })
    .catch((error) => {
      console.log(error);
    });
};

//綁定收件、收費資料
const shipName = ref("");
const shipAddress = ref("");
const shipPhone = ref("");
const payment = ref("");
const discount = ref("");
const totalIncludeHcoin = computed(() => {
  return products.value.total - discount.value;
});

//結帳
const progressing = ref(false);
const H_Coin = ref(0);
const getCoin = async () => {
  await axios
    .get("https://localhost:7243/api/HCoin/TotalHCoin")
    .then((response) => {
      H_Coin.value = response.data;
    });
};
const coinUseLimit = computed(() => {
  const twentyPercent = parseInt(products.value.total * 0.2);
  return H_Coin.value < twentyPercent ? H_Coin : twentyPercent;
});
const checkout = async () => {
  progressing.value = true;
  await axios
    .post(
      `https://localhost:7243/api/Cart/Checkout`,
      {
        payment: payment.value,
        shipVia: "黑貓", //todo。運送方式改成後台管理頁面填寫
        freight: 0, //todo，考慮運費拿掉全部免運
        discount: discount.value,
        shipName: shipName.value,
        shipAddress: shipAddress.value,
        shipPhone: shipPhone.value,
      },
      { withCredentials: true }
    )
    .then((response) => {
      axios
        .post(`https://localhost:7243/api/Paypal/${response.data}`)
        .then((response) => {
          window.location = response.data.paypalLink;
        })
        .catch((error) => {
          console.log(error);
        });
    })
    .catch((error) => {
      console.log(error);
    });
  progressing.value = false;
};
onBeforeMount(() => {
  axios
    .get("https://localhost:7243/api/Cart", { withCredentials: true })
    .then((response) => {
      if (response.data.cartItems.length === 0) {
        window.location = "http://localhost:5173/product";
      }
    })
    .catch((error) => {
      console.log(error);
    });
});

onMounted(() => {
  getCartInfo();
  getCoin();
});
</script>
<style scoped>
.custom {
  width: 200px;
  height: 200px;
  overflow: hidden;
}

.pe-6 {
  padding-right: 10%;
}

.custom img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.fz-12 {
  font-size: 13pt;
}

.btn-custom {
  border-radius: 5%;
}

.fz-sm {
  font-size: 12px;
}

.fz-10 {
  font-size: 15px;
}

.checkoutbtn:not(.nav-btns button) {
  background-color: #fff;
  color: rgb(12, 13, 12);
  padding: 10px 28px;
  border-radius: 25px;
  border: 1px solid rgb(12, 13, 12);
}

.quantity {
  pointer-events: none;
  border-radius: 0%;
}

.checkoutbtn:not(.nav-btns button):hover {
  background-color: #000000;
  color: #fff;
  border-color: #000000;
}

.textbox {
  border: none;
  border-bottom: 1px solid transparent;
  outline: none;
  font-size: 16px;
  transition: border-bottom-color 0.2s ease-in-out;
  text-align: right;
  padding-right: 4px;
}

select {
  appearance: none;
  border: none;
  border-bottom: 1px solid #ccc;
  width: 100%;
  color: #757575;
}

select:focus {
  outline: none;
}

.textbox_ship {
  border: none;
  border-bottom: 1px solid #ccc;
  outline: none;
  font-size: 16px;
  transition: border-bottom-color 0.2s ease-in-out;
}

.textbox:focus {
  border-bottom-color: #ccc;
}

.cartContent {
  min-height: 200px;
}

.modal {
  display: block;
  position: fixed;
  z-index: 9999;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(255, 255, 255, 0.5);
}

.modal-content {
  position: absolute;
  border: none;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 100px; /* 設置寬度為 200px */
  height: 100px; /* 設置高度為 200px */
  margin: auto; /* 將margin設置為auto使其垂直和水平居中 */
}
</style>