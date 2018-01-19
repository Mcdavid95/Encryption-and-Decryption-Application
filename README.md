# Encryption-and-Decryption-Application
App to encrypt and decrypt strings (Insecurely).


## Challenge

### Encryption

1. Find the nth index in an alphabet sequence ( a = 1, b = 2, c = 3, ..., z = 26)

2. Calculate the 'hash' value by using the folowing formula:
  
   a. If n is odd, multiply by 3 and add 1.
    
   b. If n is even, divide by 2.
    
3. To help with decryption, add a prefix to the hash value as below

   a. If n is even, add the 'e' character as a prefix to the hash value
    
   b. If n is odd, add the 'o' character as a prefix to the hash value
    
#### Example
    
Word | nth Index | Hash value | Encrypted Value
--- | --- | --- | ---
| TIMOTHY | 20    9    13    15    20     8    25 | 10    28   40    46    10     4    76 | o28  o40    o46   e10   e4    o76

### Decryption

1. Decrypt the encrypted string, so that 'e10o28o40o46e10e4o76' returns 'Timothy'

