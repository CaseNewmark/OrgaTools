<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import { onMounted, ref } from 'vue'
import { msalInstance, state } from './config/auth';
import { handleRedirect, login, logout } from './services/auth-service';

const accountMenu = ref();
const accountMenuItems = ref([
  {
    label: 'Logout',
    icon: 'pi pi-sign-out',
    command: () => {
      logout();
    }
  }
]);
const navigationMenuItems = ref([
  {
    label: 'Overview',
    icon: 'pi pi-home',
    route: '/'
  },
  {
    label: 'Whiteboard',
    icon: 'pi pi-pen-to-square',
    route: '/whiteboard'
  }
]);

onMounted(async () => {
  // await msalInstance.initialize();
  // await handleRedirect();
  // if (!state.isAuthenticated) {
  //   await login();
  // }
  setTimeout(async () => state.isAuthenticated = true, 1000);
});

const toggleAccountMenu = (event: PointerEvent) => {
  const val = accountMenu.value;
  val.toggle(event);
};


</script>

<template>
  <div class="flex flex-col items-center self-center min-h-screen w-200 items-stretch" v-if="state.isAuthenticated">
    <div class="flex flex-row gap-4 mt-8 mb-8">
      <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="48" height="48" />
      <Menubar :model="navigationMenuItems" class="w-full max-w-4xl">
        <template #item="{ item }">
          <router-link :to="item.route" v-slot="{ href, navigate }" custom>
            <a :href="href" @click="navigate" class="p-menubar-item-link">
              <span :class="item.icon" class="p-menubar-item-icon"></span>
              <span class="p-menubar-item-label">{{ item.label }}</span>
            </a>
          </router-link>
        </template>
        <template #end>
          <Avatar icon="pi pi-user" class="ml-auto" shape="circle" @click="toggleAccountMenu" />
          <Menu ref="accountMenu" :model="accountMenuItems" :popup="true">
            <template #start>
              <div class="px-3 py-2 border-b-1 border-gray-300">
                <div>Welcome <span class="font-bold">{{ state.user?.name }}</span></div>
              </div>
            </template>
          </Menu>
        </template>
      </Menubar>
    </div>

    <RouterView />
  </div>
  <div v-else class="flex h-screen items-center justify-center bg-gray-200">
    <ProgressSpinner />
  </div>
</template>

<style scoped>
:root {
  background-color: aquamarine;
}
</style>