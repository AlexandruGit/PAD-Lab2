# PAD-Lab2

This repository contains 2 .NET Core projects:

- PadProxy

- RestaurantOrders

The first one is for requests forwarding. 
(e.g.: we have 1 gateway(this proxy app) and multiple identical servers. 
Grant to this proxy app we can distribute the requests across these servers in order to minimize the load.)

The second one is the distributed APP itself. It's just an API project with some simple CRUD operations.
Data for this app is stored and distributed across a Cassandra cluster (a set of NoSQL DB nodes)

#### How i've run my Cassandra cluster:

- Installed the necessary prerequisites (pyhton2.7, pip, psutil, etc)
- Installed **ccm** tooling (Cassandra Cluster Manager)
- Set up the CCM (just some environment setup steps)
- Ran the following commands:
  - ccm create restaurant_orders_cluster -v 2.1.2 (downloads and installs Cassandra 2.1.2, then creates a cluster of this version)
  - ccm status (displays status info about all the Cassandra clusters on local PC)
    - Result example:
```
ccm status
Cluster: 'restaurant_orders_cluster'
------------------------------------
No node in this cluster yet
```
  - ccm populate -n 3 (creates 3 Cassandra nodes)
  - again ccm status (to see the status of the current cluster - restaurant_orders_cluster)
  ```
  Cluster: 'restaurant_orders_cluster'
  ------------------------
  node1: DOWN (Not initialized)
  node3: DOWN (Not initialized)
  node2: DOWN (Not initialized)  
  ```
  - ccm start (starts all the nodes)
  - ccm node1 show (displays info about a node (node1 in this case))
  ```
  node1: UP
  cluster=restaurant_orders_cluster
  auto_bootstrap=False
  thrift=('127.0.0.2', 9160)
  binary=('127.0.0.2', 9042)
  storage=('127.0.0.2', 7000)
  jmx_port=7100
  remote_debug_port=0
  initial_token=-9223372036854775808
  pid=17432
  ```
