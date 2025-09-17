<script setup lang="ts">
import Button from 'primevue/button'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import { ref } from 'vue'
import { Api } from '../api/ApiClient' 

//const samples = ref<Sample[]>([])
const loading = ref(false)
const error = ref<string | null>(null)


// Initialize the API client
const apiClient = new Api({
  baseURL: '', // Empty string since we're using Vite proxy
})

const fetchSamples = async () => {
  loading.value = true
  error.value = null
  try {
    console.log('Starting fetch request using ApiClient...')

    // Use the ApiClient to fetch samples
    const response = await apiClient.apiInfo.apiInfoList();

    console.log('Response received:', response.status, response.statusText)
    
    //samples.value = response.data || []
    console.log('Samples fetched successfully:', response.data)
    
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

fetchSamples();
</script>

<template>
  <div class="mt-4 border-1 border-gray-200 rounded-md overflow-hidden">
    <DataTable stripedRows paginator :rows="10" scrollable :loading="loading" class="bg-white">
      <Column field="name" header="Serial" class="w-25"/>
      <Column field="description" header="Description">
        <template #body="{ data }">
          <div class="w-110 truncate">{{ data.description }}</div>
        </template>
      </Column>
      <Column field="fullProductName" header="Model" class="w-50" />
      <!-- <template #paginatorcontainer="{ }">
        <div class="flex justify-end items-end p-2 w-full">
          <Button icon="pi pi-chevron-left" text severity="secondary" @click="prevPageCallback" :disabled="currentOffset == 0" />
          <Button icon="pi pi-chevron-right" text severity="secondary" @click="nextPageCallback" />
        </div>
      </template> -->
    </DataTable>
  </div>
</template>