package main

import "fmt"

var ct = []byte{42, 12, 34, 13, 54, 13, 13, 14, 44, 12, 13, 22, 33, 14, 24, 31, 51, 53, 53, 55, 12, 25, 12, 13, 52, 55, 14, 31, 45, 14, 31, 13, 12, 53, 51, 12, 25, 12, 42, 51, 34, 54, 23, 14, 45, 12, 34, 13, 23, 45, 34, 23, 23, 45, 12, 53, 51, 35, 13, 34, 13, 33, 31, 51, 53, 53, 13, 12, 54, 34, 51, 55, 51, 55, 23, 34, 41, 23, 34, 55, 42, 45, 12, 13, 12, 34, 23, 23, 45, 12, 54, 34, 55, 14, 13, 51, 52, 55, 14, 31, 23, 45, 34, 23, 33, 14, 24, 31, 12, 13, 12, 52, 12, 12, 55, 23, 14, 22, 24, 15, 15, 14, 13, 23, 14, 24, 13, 41, 51, 23, 33, 51, 55, 51, 23, 22, 34, 54, 35, 51, 23, 51, 14, 55, 23, 14, 13, 51, 25, 34, 53, 55, 12, 31, 33, 14, 13, 52, 31, 51, 23, 45, 51, 23, 22, 34, 22, 23, 14, 13, 34, 55, 42, 53, 12, 55, 55, 14, 32, 53, 51, 35, 13, 34, 13, 51, 12, 22, 35, 24, 23, 23, 14, 44, 12, 23, 45, 12, 13, 31, 12, 45, 34, 25, 12, 22, 15, 12, 55, 23, 41, 14, 55, 22, 51, 42, 12, 13, 34, 35, 53, 12, 12, 43, 43, 14, 13, 23, 35, 24, 51, 53, 42, 51, 55, 44, 34, 24, 55, 51, 21, 24, 12, 41, 14, 53, 53, 12, 41, 23, 51, 14, 55, 14, 43, 13, 34, 13, 12, 34, 55, 42, 51, 54, 15, 14, 13, 23, 34, 55, 23, 31, 14, 13, 52, 22, 34, 55, 42, 51, 31, 14, 24, 53, 42, 45, 34, 25, 12, 35, 12, 12, 55, 42, 12, 12, 15, 53, 33, 22, 34, 42, 42, 12, 55, 12, 42, 23, 14, 53, 14, 22, 12, 51, 23, 51, 31, 34, 22, 23, 14, 24, 41, 45, 12, 42, 35, 33, 33, 14, 24, 13, 14, 43, 43, 12, 13, 23, 14, 54, 34, 52, 12, 51, 23, 34, 41, 14, 55, 42, 51, 23, 51, 14, 55, 14, 43, 23, 45, 12, 42, 14, 55, 34, 23, 51, 14, 55, 23, 45, 34, 23, 51, 22, 45, 14, 24, 53, 42, 41, 14, 55, 23, 51, 55, 24, 12, 23, 14, 35, 12, 12, 54, 15, 53, 14, 33, 12, 42, 34, 22, 23, 45, 12, 41, 24, 13, 34, 23, 14, 13, 35, 24, 23, 23, 45, 12, 54, 34, 55, 14, 13, 51, 22, 54, 33, 45, 14, 54, 12, 34, 22, 31, 12, 53, 53, 34, 22, 54, 33, 31, 14, 13, 52, 15, 53, 34, 41, 12, 34, 55, 42, 51, 23, 43, 12, 12, 53, 22, 13, 51, 44, 45, 23, 23, 45, 34, 23, 23, 45, 51, 22, 51, 54, 15, 14, 13, 23, 34, 55, 23, 41, 14, 53, 53, 12, 41, 23, 51, 14, 55, 14, 43, 13, 34, 13, 12, 35, 14, 14, 52, 22, 22, 45, 14, 24, 53, 42, 13, 12, 54, 34, 51, 55, 45, 12, 13, 12, 51, 55, 15, 13, 51, 25, 34, 23, 12, 45, 34, 55, 42, 22, 31, 45, 12, 13, 12, 51, 41, 34, 55, 41, 34, 13, 12, 43, 14, 13, 51, 23, 15, 13, 14, 15, 12, 13, 53, 33, 51, 34, 54, 22, 14, 13, 13, 33, 23, 14, 45, 12, 34, 13, 23, 45, 34, 23, 33, 14, 24, 31, 51, 53, 53, 35, 12, 31, 51, 23, 45, 42, 13, 34, 31, 51, 55, 44, 43, 13, 14, 54, 23, 45, 12, 13, 34, 41, 12, 43, 14, 13, 44, 14, 25, 12, 13, 55, 14, 13, 34, 22, 51, 52, 55, 14, 31, 23, 45, 34, 23, 31, 34, 22, 34, 41, 45, 12, 13, 51, 22, 45, 12, 42, 34, 54, 35, 51, 23, 51, 14, 55, 51, 34, 54, 22, 24, 13, 12, 33, 14, 24, 31, 14, 24, 53, 42, 45, 34, 25, 12, 43, 51, 53, 53, 12, 42, 23, 45, 12, 13, 14, 53, 12, 31, 51, 23, 45, 42, 51, 22, 23, 51, 55, 41, 23, 51, 14, 55, 35, 24, 23, 23, 45, 12, 13, 12, 31, 51, 53, 53, 35, 12, 14, 23, 45, 12, 13, 31, 34, 33, 22, 23, 14, 22, 12, 13, 25, 12, 34, 55, 42, 51, 23, 45, 51, 55, 52, 33, 14, 24, 34, 13, 12, 13, 51, 44, 45, 23, 23, 45, 34, 23, 23, 45, 12, 22, 23, 13, 34, 55, 44, 12, 42, 12, 34, 23, 45, 14, 43, 22, 23, 34, 55, 53, 12, 33, 51, 22, 53, 12, 22, 31, 14, 24, 53, 42, 45, 34, 25, 12, 24, 55, 42, 12, 13, 54, 51, 55, 12, 42, 33, 14, 24, 13, 41, 34, 54, 15, 34, 51, 44, 55, 31, 12, 52, 55, 14, 31, 31, 45, 34, 23, 44, 14, 22, 22, 51, 15, 41, 34, 55, 42, 14, 51, 55, 23, 45, 12, 22, 54, 34, 53, 53, 31, 14, 13, 53, 42, 14, 43, 13, 45, 14, 42, 12, 51, 22, 53, 34, 55, 42, 22, 14, 41, 51, 12, 23, 33, 34, 55, 42, 33, 14, 24, 13, 14, 15, 15, 14, 55, 12, 55, 23, 22, 31, 14, 24, 53, 42, 45, 34, 25, 12, 23, 34, 52, 12, 55, 44, 13, 12, 34, 23, 15, 53, 12, 34, 22, 24, 13, 12, 51, 55, 22, 15, 12, 41, 24, 53, 34, 23, 51, 55, 44, 14, 55, 23, 45, 12, 24, 55, 12, 32, 15, 53, 34, 51, 55, 12, 42, 42, 12, 34, 23, 45, 51, 55, 33, 14, 24, 13, 45, 14, 54, 12, 34, 22, 33, 14, 24, 13, 12, 21, 24, 12, 22, 23, 12, 42, 51, 45, 34, 25, 12, 41, 14, 54, 15, 53, 12, 23, 12, 42, 54, 33, 34, 24, 42, 51, 23, 14, 43, 23, 45, 12, 53, 51, 35, 13, 34, 13, 33, 41, 14, 55, 23, 12, 55, 23, 22, 34, 55, 42, 51, 41, 34, 55, 34, 22, 22, 24, 13, 12, 33, 14, 24, 23, 45, 34, 23, 55, 14, 23, 45, 51, 55, 44, 51, 22, 54, 51, 22, 22, 51, 55, 44, 34, 55, 42, 55, 14, 35, 14, 14, 52, 22, 45, 34, 25, 12, 35, 12, 12, 55, 45, 34, 13, 54, 12, 42, 51, 31, 51, 53, 53, 14, 43, 41, 14, 24, 13, 22, 12, 41, 14, 55, 23, 51, 55, 24, 12, 23, 14, 15, 13, 14, 23, 12, 41, 23, 23, 45, 12, 54, 34, 55, 42, 51, 45, 14, 15, 12, 33, 14, 24, 31, 51, 53, 53, 34, 44, 13, 12, 12, 23, 45, 34, 23, 51, 23, 51, 22, 31, 14, 13, 23, 45, 41, 14, 55, 23, 51, 55, 24, 51, 55, 44, 23, 14, 51, 55, 25, 12, 22, 23, 51, 55, 23, 45, 12, 41, 14, 53, 53, 12, 41, 23, 51, 14, 55, 23, 14, 44, 12, 23, 45, 12, 13, 31, 12, 41, 34, 55, 35, 24, 51, 53, 42, 51, 23, 51, 55, 23, 14, 14, 55, 12, 14, 43, 23, 45, 12, 43, 51, 55, 12, 22, 23, 34, 13, 41, 45, 51, 25, 12, 22, 14, 43, 34, 54, 12, 13, 51, 41, 34, 55, 53, 51, 23, 12, 13, 34, 23, 24, 13, 12, 14, 55, 23, 45, 12, 12, 34, 22, 23, 41, 14, 34, 22, 23, 51, 24, 55, 42, 12, 13, 22, 23, 34, 55, 42, 23, 45, 34, 23, 33, 14, 24, 13, 55, 51, 12, 41, 12, 55, 34, 55, 41, 33, 31, 51, 53, 53, 35, 12, 25, 51, 22, 51, 23, 51, 55, 44, 55, 12, 32, 23, 31, 12, 12, 52, 34, 55, 42, 51, 53, 14, 14, 52, 43, 14, 13, 31, 34, 13, 42, 23, 14, 22, 12, 12, 51, 55, 44, 45, 12, 13, 34, 44, 34, 51, 55, 31, 45, 51, 53, 12, 22, 45, 12, 42, 14, 12, 22, 55, 14, 23, 22, 45, 34, 13, 12, 14, 24, 13, 53, 14, 25, 12, 14, 43, 43, 51, 55, 12, 35, 14, 14, 52, 22, 22, 45, 12, 41, 12, 13, 23, 34, 51, 55, 53, 33, 53, 14, 25, 12, 22, 23, 45, 51, 22, 45, 14, 24, 22, 12, 34, 55, 42, 51, 34, 54, 22, 24, 13, 12, 22, 45, 12, 31, 51, 53, 53, 45, 34, 25, 12, 45, 12, 13, 14, 31, 55, 51, 42, 12, 34, 22, 34, 35, 14, 24, 23, 45, 14, 31, 23, 14, 43, 13, 12, 22, 45, 12, 55, 51, 23, 24, 15, 51, 13, 12, 54, 34, 51, 55, 34, 53, 14, 33, 34, 53, 22, 12, 13, 25, 34, 55, 23, 23, 14, 33, 14, 24, 34, 55, 42, 23, 14, 23, 45, 12, 53, 51, 35, 13, 34, 13, 33, 54, 34, 51, 22, 51, 12}

func main() {
	buf := make([]byte, len(ct))
	for i, c := range ct {
		buf[i] = 'A' + 5*(c/10-1) + c%10 - 1
	}
	fmt.Println(string(buf))
}
