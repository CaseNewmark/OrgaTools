<script setup lang="ts">
import Button from 'primevue/button'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import { ref } from 'vue'
import { Api, type RouterDto } from '@/api/DocApiClient'

const routers = ref<RouterDto[]>([])
const loading = ref(false)
const error = ref<string | null>(null)

let currentOffset = 0

// Initialize the API client
const apiClient = new Api({
  baseURL: '', // Empty string since we're using Vite proxy
})

const fetchRouters = async () => {
  loading.value = true
  error.value = null
  try {
    console.log('Starting fetch request using DocApiClient...')
    
    // Use the DocApiClient to fetch routers
    const response = await apiClient.api.getAllRouters({
      limit: 10,
      offset: currentOffset
    })

    console.log('Response received:', response.status, response.statusText)
    
    routers.value = response.data || []
    console.log('Routers fetched successfully:', response.data)
    
  } catch (err) {
    console.error('Fetch error details:', err)
    
    if (err instanceof TypeError) {
      error.value = 'Network error: Unable to connect to the API. Make sure the API service is running.'
    } else if (err instanceof Error) {
      error.value = `API Error: ${err.message}`
    } else {
      error.value = 'An unknown error occurred'
    }
  } finally {
    loading.value = false
  }
}

const prevPageCallback = async (event: any) => {
  console.log('Paginator event:', event);
  currentOffset = currentOffset == 0 ? 0 : currentOffset - 10; // Update the offset based on the paginator event
  fetchRouters(); // Fetch routers with the new offset
};

const nextPageCallback = async (event: any) => {
  console.log('Paginator event:', event);
  currentOffset += 10; // Update the offset based on the paginator event
  fetchRouters(); // Fetch routers with the new offset
};

fetchRouters();
</script>

<template>
  <div class="mt-4 border-1 border-gray-200 rounded-md overflow-hidden">
    <DataTable stripedRows paginator :rows="10" scrollable :value="routers" :loading="loading" class="bg-white">
      <Column field="name" header="Serial" class="w-25"/>
      <Column field="description" header="Description">
        <template #body="{ data }">
          <div class="w-110 truncate">{{ data.description }}</div>
        </template>
      </Column>
      <Column field="fullProductName" header="Model" class="w-50" />
      <template #paginatorcontainer="{ }">
        <div class="flex justify-end items-end p-2 w-full">
          <Button icon="pi pi-chevron-left" text severity="secondary" @click="prevPageCallback" :disabled="currentOffset == 0" />
          <Button icon="pi pi-chevron-right" text severity="secondary" @click="nextPageCallback" />
        </div>
      </template>
    </DataTable>
  </div>
</template>
