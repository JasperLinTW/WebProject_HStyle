const routes = [
    { path: '/',name:'Home', component: ()=> import('../views/Home.vue') },
    { path: '/product',name:'Product', component:()=> import('../views/product.vue') },
    { path: '/recommend',name:'Recommend', component:()=> import('../views/Recommend.vue') },
    { path: '/blog',name:'Blog', component:()=> import('../views/Blog.vue') },
    { path: '/member',name:'member', component:()=> import('../views/Member.vue') },
    { path: '/MemberLogin',name:'MemberLogin', component:()=> import('../views/MemberLogin.vue') }

  ]
export default routes