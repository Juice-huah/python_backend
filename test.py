print("Hello World")

if __name__ == "__main__":
    print("This script is being run directly.")
else:
    print("This script is being imported as a module.")

count = 0
for i in range(1, 9):
    print(f"{i} is the number")
    count += 1

while count > 1:
    print("Printing...")
    count -= 1
print("Done!")

#Function declaration and usage
def shoutout(name = "Meowmeow"):
    print("Shouting out")
    return f"HI {name}"

message = shoutout("Boploks")
print(message) 

#Error handling
try:
    number = int(input("Enter a number: "))
    result = 10 / number
except ValueError:
    print("That's not a valid number!")
except ZeroDivisionError:
    print("You can't divide by zero!")

print(result)

