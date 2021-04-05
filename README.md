# Pury
Functional Reactive Decentralized State Management for User Interfaces

Learn by example:

```C#
Variable x, y, z

z = x / y

```

This assignment means *binding*, whenever *x* or *y* is changed, *z* is updated. 

Such assignment can bind variables in either directions, on the same object, or across two different objects; as a result the variables and bindings might form *any* network.

Unlike other frameworks, the updates are predictable, with no redundant updates and happens between the variables.

The set of variables aims to be a **consistent UI application state**: the variables contains the values that reflect the recent inputs and bindings which flow them.







