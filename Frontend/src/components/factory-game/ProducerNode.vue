<script setup lang="ts">
import type { ProducerNodeData } from '@/models/factory-game/ProducerNodeData'
import BaseNode from './BaseNode.vue'

defineProps<{
  data: ProducerNodeData
}>()
</script>

<template>
  <BaseNode :name="data.name">
    <template #icon>
      <i class="pi pi-box"></i>
    </template>
  </BaseNode>
</template>
