export function formatIdCard(rncIdCard) {
  if (rncIdCard.length === 11) {
    return rncIdCard.substring(0, 3) + "-" + rncIdCard.substring(3, 10) + "-" + rncIdCard.charAt(10)
  } else {
    return rncIdCard
  }
}

export function toTitleCase(title) {
  title = title.toLowerCase()
  const words = title.split(' ')
  for (let i = 0; i < words.length; i++) {
    words[i] = words[i].charAt(0).toUpperCase() + words[i].slice(1)
  }
  title = words.join(' ')
  return title
}