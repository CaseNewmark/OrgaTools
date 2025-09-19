<script setup>
  import { ref } from 'vue'  
  import { Handle, Position, useNodeConnections, useNodesData } from '@vue-flow/core'

  // const connections = useNodeConnections({
  //     handleType: 'target',
  // })

  // const nodesData = useNodesData(() => connections.value[0]?.source)
</script>

<template>
  <div class="w-10 h-10 bg-gray-100 text-gray-800 flex items-center justify-center rounded-xs border-1 border-gray-300">
    <!-- {{  nodesData?.value?.label || 'Node'  }} -->
  </div>
</template>
