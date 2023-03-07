const routes = [
    { path: '/',name:'Home', component: ()=> import('../views/Home.vue') },
    { path: '/product',name:'Product', component:()=> import('../views/product.vue') },
    { path: '/product/:id',name:'SingleProduct', component:()=> import('../views/SingleProduct.vue') },
    { path: '/recommend',name:'Recommend', component:()=> import('../views/Recommend.vue') },
    { path: '/blog',name:'Blog', component:()=> import('../views/Blog.vue') },
    { path: '/checkout',name:'Checkout', component:()=> import('../views/Checkout.vue') },
    { path: '/account',name: 'Account', component:() => import('../views/Account.vue'),children: [
      { path: 'orders',component: () => import('../components/Orders.vue')},
      { path: 'MemberProfile',component: () => import('../components/MemberProfile.vue')},
      { path: 'MemberCollection',component: () => import('../components/MemberCollection.vue')},
      { path: 'MemberAddresses',component: () => import('../components/MemberAddresses.vue')},
    ]},
    { path: '/EssaysBlog',name:'EssaysBlog', component:()=> import('../views/EssaysBlog.vue') },
    { path: '/member',name:'member', component:()=> import('../views/Member.vue') },
    { path: '/LogIn',name:'LogIn', component:()=> import('../views/LogIn.vue') },

  ]
export default routes