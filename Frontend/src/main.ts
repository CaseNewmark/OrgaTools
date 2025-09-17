import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config'
import Aura from '@primeuix/themes/aura'
import Menubar from 'primevue/menubar'
import Button from 'primevue/button'
import Avatar from 'primevue/avatar'
import Menu from 'primevue/menu'
import ProgressSpinner from 'primevue/progressspinner';

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(PrimeVue, {
  theme: {
    preset: Aura,
  },
})
app.component('Menubar', Menubar)
app.component('Button', Button)
app.component('Avatar', Avatar)
app.component('Menu', Menu)
app.component('ProgressSpinner', ProgressSpinner);

app.mount('#app')
